//Function for calculating Stoichiometric ratios
function MixChar() {
    var cfx = $('#CFX')[0].value;
    var svo = $('#SVO')[0].value;
    
    $('#Ratio')[0].value = (((cfx * 786) / (svo * 270)).toFixed(0));
    $('#mAh')[0].value = ((((cfx / 100) * 786) + ((svo / 100) * 270)).toFixed(1));    
    $('#ActiveMaterial')[0].value = ((parseFloat(cfx) + parseFloat(svo)).toFixed(1));
}
