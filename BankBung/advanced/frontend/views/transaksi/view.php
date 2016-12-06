<?php

use yii\helpers\Html;
use yii\widgets\DetailView;

/* @var $this yii\web\View */
/* @var $model frontend\models\Transaksi */

$this->title = $model->id;
$this->params['breadcrumbs'][] = ['label' => 'Transaksis', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="transaksi-view">
    <?= DetailView::widget([
        'model' => $model,
        'attributes' => [
            'id',
            'jenis_transaksi',
            'kode_transaksi',
            'rekening_asal',
            'rekening_tujuan',
            'jumlah',
        ],
    ]) ?>

</div>
