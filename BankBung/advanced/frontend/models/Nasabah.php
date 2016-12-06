<?php

namespace frontend\models;

use Yii;
use common\models\User;
/**
 * This is the model class for table "nasabah".
 *
 * @property integer $id
 * @property string $nomor_kartu
 * @property string $pin
 * @property string $nomor_rekening
 * @property integer $saldo
 * @property integer $id_akun
 *
 * @property User $idAkun
 * @property Transaksi[] $transaksis
 * @property Transaksi[] $transaksis0
 */
class Nasabah extends \yii\db\ActiveRecord
{
    /**
     * @inheritdoc
     */
    public static function tableName()
    {
        return 'nasabah';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['saldo', 'id_akun'], 'integer'],
            [['nomor_kartu', 'pin', 'nomor_rekening'], 'string', 'max' => 250],
            [['id_akun'], 'exist', 'skipOnError' => true, 'targetClass' => User::className(), 'targetAttribute' => ['id_akun' => 'id']],
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'nomor_kartu' => 'Nomor Kartu',
            'pin' => 'Pin',
            'nomor_rekening' => 'Nomor Rekening',
            'saldo' => 'Saldo',
            'id_akun' => 'Id Akun',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getIdAkun()
    {
        return $this->hasOne(User::className(), ['id' => 'id_akun']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getTransaksis()
    {
        return $this->hasMany(Transaksi::className(), ['rekening_asal' => 'id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getTransaksis0()
    {
        return $this->hasMany(Transaksi::className(), ['rekening_tujuan' => 'id']);
    }
}
