<?php

namespace frontend\controllers;

use Yii;
use frontend\models\Transaksi;
use frontend\models\TransaksiSearch;
use yii\web\Controller;
use yii\web\NotFoundHttpException;
use yii\filters\VerbFilter;
use common\models\User;
use frontend\models\Nasabah;
/**
 * TransaksiController implements the CRUD actions for Transaksi model.
 */
class TransaksiController extends Controller
{
    /**
     * @inheritdoc
     */
    public function behaviors()
    {
        return [
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                    'delete' => ['POST'],
                ],
            ],
        ];
    }

    /**
     * Lists all Transaksi models.
     * @return mixed
     */
    public function actionIndex()
    {
        $searchModel = new TransaksiSearch();
        $dataProvider = $searchModel->search(Yii::$app->request->queryParams);

        return $this->render('index', [
            'searchModel' => $searchModel,
            'dataProvider' => $dataProvider,
        ]);
    }

    /**
     * Displays a single Transaksi model.
     * @param integer $id
     * @return mixed
     */
    public function actionView($id)
    {
        return $this->render('view', [
            'model' => $this->findModel($id),
        ]);
    }

    /**
     * Creates a new Transaksi model.
     * If creation is successful, the browser will be redirected to the 'view' page.
     * @return mixed
     */
    public function actionCreate()
    {
        $model = new Transaksi();
        $user = Yii::$app->user->identity->id;
        $asal = Nasabah::find()->where(['id_akun'=>$user])->one();
        if ($model->load(Yii::$app->request->post())) 
        {
            if(Nasabah::find()->where(['nomor_rekening' => $model->tujuan])->count()==0)
            {
                Yii::$app->session->setFlash('danger', 'Nomor Rekening Tujuan Tidak Terdaftar!!');
                return $this->redirect(['create']);
            }
            else
            {
                $tujuan = Nasabah::find()->where(['nomor_rekening'=>$model->tujuan])->one();
                //echo $tujuan->nomor_rekening.'<br>';
                //echo $asal->nomor_rekening;
                $model->rekening_asal = $asal->id;
                $model->rekening_tujuan = $tujuan->id;
                $date = date('Y-m-d H:i:s');
                $model->waktu_tansaksi = $date;
                $model->jenis_transaksi = "keluar";
                //die();
                $model->save();
                $asal->saldo = $asal->saldo - $model->jumlah;
                $asal->save(false);
                $tujuan->saldo = $tujuan->saldo + $model->jumlah;
                $tujuan->save();
                
                $transaksi = new Transaksi();
                $transaksi->jumlah = $model->jumlah;
                $transaksi->jenis_transaksi = "masuk";
                $transaksi->kode_transaksi = $model->kode_transaksi;
                $transaksi->rekening_asal = $model->rekening_asal;
                $transaksi->rekening_tujuan = $model->rekening_tujuan;
                $transaksi->waktu_tansaksi = $date;
                $transaksi->save(false);
            }
            Yii::$app->session->setFlash('success', 'Transaksi Berhasil Dilakukan!!');
            return $this->redirect(['view', 'id' => $model->id]);
        } 
        else
        {
            return $this->render('create', [
                'model' => $model,
            ]);
        }
    }

    /**
     * Updates an existing Transaksi model.
     * If update is successful, the browser will be redirected to the 'view' page.
     * @param integer $id
     * @return mixed
     */
    public function actionUpdate($id)
    {
        $model = $this->findModel($id);

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['view', 'id' => $model->id]);
        } else {
            return $this->render('update', [
                'model' => $model,
            ]);
        }
    }

    /**
     * Deletes an existing Transaksi model.
     * If deletion is successful, the browser will be redirected to the 'index' page.
     * @param integer $id
     * @return mixed
     */
    public function actionDelete($id)
    {
        $this->findModel($id)->delete();

        return $this->redirect(['index']);
    }

    /**
     * Finds the Transaksi model based on its primary key value.
     * If the model is not found, a 404 HTTP exception will be thrown.
     * @param integer $id
     * @return Transaksi the loaded model
     * @throws NotFoundHttpException if the model cannot be found
     */
    protected function findModel($id)
    {
        if (($model = Transaksi::findOne($id)) !== null) {
            return $model;
        } else {
            throw new NotFoundHttpException('The requested page does not exist.');
        }
    }
}
