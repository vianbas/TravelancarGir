<?php

namespace frontend\controllers;
use frontend\models\Transaksi;
class ApiController extends \yii\web\Controller
{
   /**
     * @inheritdoc
     */
    public function actions()
    {
        return [
            'index' => 'mongosoft\soapserver\Action',
        ];
    }

    /**
     * @param string $name
     * @return string
     * @soap
     */
    public function getIndex($kodetransaksi,$jumlah)
    {
         if(Transaksi::find()->where(['kode_transaksi'=>$kodetransaksi])->andWhere(['jumlah'=>$jumlah])->count()==0){
            return "0";
        }
        else{
            return "1";
        }
    }

}
