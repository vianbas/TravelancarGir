<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "transaksi".
 *
 * @property integer $id
 * @property string $jenis_transaksi
 * @property string $kode_transaksi
 * @property integer $rekening_asal
 * @property integer $rekening_tujuan
 * @property integer $jumlah
 * @property string $waktu_tansaksi
 *
 * @property Nasabah $rekeningAsal
 * @property Nasabah $rekeningTujuan
 */
class Transaksi extends \yii\db\ActiveRecord
{
    /**
     * @inheritdoc
     */
    public $tujuan;
    public static function tableName()
    {
        return 'transaksi';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['jenis_transaksi'], 'string'],
            [['rekening_asal', 'rekening_tujuan', 'jumlah'], 'integer'],
            [['tujuan', 'kode_transaksi', 'jumlah'], 'required'],
            [['waktu_tansaksi'], 'safe'],
            [['kode_transaksi'], 'string', 'max' => 250],
            [['rekening_asal'], 'exist', 'skipOnError' => true, 'targetClass' => Nasabah::className(), 'targetAttribute' => ['rekening_asal' => 'id']],
            [['rekening_tujuan'], 'exist', 'skipOnError' => true, 'targetClass' => Nasabah::className(), 'targetAttribute' => ['rekening_tujuan' => 'id']],
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'jenis_transaksi' => 'Jenis Transaksi',
            'kode_transaksi' => 'Kode Transaksi',
            'rekening_asal' => 'Rekening Asal',
            'rekening_tujuan' => 'Rekening Tujuan',
            'jumlah' => 'Jumlah',
            'tujuan' => 'Nomor Rekening Tujuan',
            'waktu_tansaksi' => 'Waktu Tansaksi',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getRekeningAsal()
    {
        return $this->hasOne(Nasabah::className(), ['id' => 'rekening_asal']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getRekeningTujuan()
    {
        return $this->hasOne(Nasabah::className(), ['id' => 'rekening_tujuan']);
    }
}
