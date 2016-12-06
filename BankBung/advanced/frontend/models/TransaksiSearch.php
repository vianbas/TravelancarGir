<?php

namespace frontend\models;

use Yii;
use yii\base\Model;
use yii\data\ActiveDataProvider;
use frontend\models\Transaksi;

/**
 * TransaksiSearch represents the model behind the search form about `frontend\models\Transaksi`.
 */
class TransaksiSearch extends Transaksi
{
    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['id', 'rekening_asal', 'rekening_tujuan', 'jumlah'], 'integer'],
            [['jenis_transaksi', 'kode_transaksi'], 'safe'],
        ];
    }

    /**
     * @inheritdoc
     */
    public function scenarios()
    {
        // bypass scenarios() implementation in the parent class
        return Model::scenarios();
    }

    /**
     * Creates data provider instance with search query applied
     *
     * @param array $params
     *
     * @return ActiveDataProvider
     */
    public function search($params)
    {
        $query = Transaksi::find();

        // add conditions that should always apply here

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            // uncomment the following line if you do not want to return any records when validation fails
            // $query->where('0=1');
            return $dataProvider;
        }

        // grid filtering conditions
        $query->andFilterWhere([
            'id' => $this->id,
            'rekening_asal' => $this->rekening_asal,
            'rekening_tujuan' => $this->rekening_tujuan,
            'jumlah' => $this->jumlah,
        ]);

        $query->andFilterWhere(['like', 'jenis_transaksi', $this->jenis_transaksi])
            ->andFilterWhere(['like', 'kode_transaksi', $this->kode_transaksi]);

        return $dataProvider;
    }
}
