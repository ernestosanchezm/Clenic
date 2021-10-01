
//Funcion para pintar fila si tiene completo sus auditores x negocio o distrito
function activarRespuesta1(ubigeo) {

    if (sendInsertEnc != null && sendInsertEnc.length > 0) {
        //console.log(sendInsertEnc);
        var objDistrito = sendInsertEnc.find(e => e.ubigeo == ubigeo);
        //if (ubigeo == '070102')
        //    console.log(objDistrito);

        //Validar distrito sin negocio
        //if (objDistrito.listPv.length == 0) {
        if (objDistrito.numPv == 0) {

            var selectDelDistrito = $('#lstaAuditores' + ubigeo).select2('data');
            if (selectDelDistrito.length > 0) {
                //El distrito tiene auditores seleccionados
                $('#' + ubigeo).css('background-color', '#B0E1B7');
            }
            else {
                //El distrito no tiene auditores seleccionados
                $('#' + ubigeo).css('background-color', '#FFFFFF');
            }
            return;

        }

        //Validar distrito con negocio
        else {

            var iSizeAllPvWorkedUp = 0;
            $.each(objDistrito.listPv, function (i1, e1) {
                if (e1.iWorkedUp == 1) iSizeAllPvWorkedUp++;
            });
            /*if (ubigeo == '070102') {
                console.log(objDistrito);
                console.log(iSizeAllPvWorkedUp);
            }*/
            //if (objDistrito.listPv.length == iSizeAllPvWorkedUp) {
            if (objDistrito.numPv == iSizeAllPvWorkedUp) {
                //El distrito tiene auditores seleccionados
                $('#' + ubigeo).css('background-color', '#B0E1B7');
                /*if (ubigeo == '070102')
                    console.log('#B0E1B7');*/
            }
            else {
                //El distrito no tiene completos sus auditores seleccionados
                $('#' + ubigeo).css('background-color', '#FFFFFF');
                /*if (ubigeo == '070102')
                    console.log('#FFFFFF');*/
            }

            return;
        }
    }
}


function GenerarEncuestas1() {

    var urlPlanifInsertarEncuestas1 = $('#planifInsertarEncuestas1').data('request-url');
    var urlPlanifAddEdit1 = $('#planifAddEdit1').data('request-url');

    $('#genEnc').prop('disabled', true);
    $('#saveEstado').prop('disabled', true);

    var _idMes = $('#idMes').val();    // MES
    var _idAno = $('#idAno').val();    // AÑO
    var _ffin = $('#ffin').val();
    var _finicio = $('#finicio').val();
    var _dscPlan = $('#dscPlanificacion').val();
    var _idTipoEstudio = $('#slctTipoEstudio').val();
    var _idFrecuencia = $('#slctFrecuencia').val();
    //VALIDAR QUE TODOS LOS UBIGEOS ESTEN SELECCIONADOS Y AVISAR
    //var sizeDistConAuditSel = sendInsertEnc.length;
    var sizeAllUbigeos = resTblPlan.length;
    var sizeDistConAuditSel = 0;
    var iSizeAllPv = 0;
    var iSizeAllPvWorkedUp = 0;
    //var listZonaId = []
    //$($('#slctZona1').select2('data')).each((i, e) => { listZonaId.push(e.id); });

    //CONSTRUCCION DEL OBJETO SENDINSERTENC
    var lstaPtosYAuditInsert = [];
    $.each(sendInsertEnc, function (i, e) {
        $.each(e.listPv, function (i1, e1) {
            lstaPtosYAuditInsert.push(e1);
            iSizeAllPv++;
            if (e1.iWorkedUp === 1) iSizeAllPvWorkedUp++;
        });
    });

    //Crear objeto PDZona
    var listPDZona = [];
    //Obteniendo Lista de zonas
    var listZonaId1 = [];
    $.each(resTblPlan, function (i, e) {
        if (jQuery.inArray(e.zonaId, listZonaId1) == -1) {
            listZonaId1.push(e.zonaId)
        }
    });
    console.log(listZonaId1);

    //Loop Zona
    listZonaId1.forEach(function (item, index) {
        var zonaId = item;
        console.log(zonaId);

        var objZonaReg = {
            zonaId: zonaId,
            ListPDDistrito: []
        };

        //Loop Distrito
        $.each(resTblPlan, function (idist, dist) {
            if (dist.zonaId == zonaId) {
                console.log(dist);
                //Obtener lista de auditores
                var selectDelDistrito = $('#lstaAuditores' + dist.ubigeo)[0].selectedOptions;
                var auditoresSel = [];  //lista de auditores seleccionados
                $.each(selectDelDistrito, function (iaudit, audit) { auditoresSel.push(audit.value); });
                if (auditoresSel != null & auditoresSel.length > 0) sizeDistConAuditSel++;

                //Crear objDistReg
                var objDistReg = {
                    ubigeo: dist.ubigeo,
                    listAuditorId: auditoresSel
                };

                objZonaReg.ListPDDistrito.push(objDistReg);
            }
        });

        listPDZona.push(objZonaReg);

    });

    var objSendInsertEnc = {
        descripcionPlan: _dscPlan,
        idFrecuencia: _idFrecuencia,
        idTipoEstudio: _idTipoEstudio,
        listPv: CopyArr(lstaPtosYAuditInsert),
        finicio: _finicio,
        ffin: _ffin,
        idAno: parseInt(_idAno),
        idMes: _idMes,
        //listZonaId: listZonaId,
        listPDZona: CopyArr(listPDZona)
    };

    var objDebug = {
        sizeDistConAuditSel: sizeDistConAuditSel,
        sizeAllUbigeos: sizeAllUbigeos,
        //sizeDistConAuditSel: sizeDistConAuditSel
        iSizeAllPv: iSizeAllPv,
        iSizeAllPvWorkedUp: iSizeAllPvWorkedUp
    };
    //console.log(objSendInsertEnc);
    //console.log(objDebug);
    console.log(JSON.stringify(objSendInsertEnc));
    console.log(JSON.stringify(objDebug));

    if (iSizeAllPvWorkedUp == 0 || sizeAllUbigeos > sizeDistConAuditSel || iSizeAllPv > iSizeAllPvWorkedUp) {
        //if (sizeDistConAuditSel == 0 || sizeAllUbigeos > sizeDistConAuditSel) {
        Swal.fire({
            title: 'Asigne auditores a los distritos!',
            text: "Tiene que seleccionar auditores a todos los distritos",
            icon: 'warning',
            confirmButtonText: 'OK'
        });
        $('#genEnc').prop('disabled', false);
        $('#saveEstado').prop('disabled', false);
        return;
    }
    else if (sizeAllUbigeos == sizeDistConAuditSel && iSizeAllPv == iSizeAllPvWorkedUp) {

        Swal.fire({
            title: 'Procesando!',
            text: 'Registrando encuestas.....',
            allowOutsideClick: false,
            allowEscapeKey: false,
            allowEnterKey: false,
            onOpen: () => {
                Swal.showLoading();
            }
        });
        //var ruta = "@Url.Action("InsertarEncuestas1", "Planificacion")";
        var ruta = urlPlanifInsertarEncuestas1;
        return axios({
            method: 'post',
            url: ruta,
            data: objSendInsertEnc
        }).then(data => {

            Swal.hideLoading();
            if (data.data.icon == "error") {
                console.log(data);
                return swalShowErrorMsg(data.data.text);
            } else {
                return Swal.fire({
                    icon: 'success',
                    title: 'Correcto'
                    //}).then(res => window.location = "@Url.Action("Index", "Planificacion")");
                //}).then(res => window.location = '@Url.Action("AddEdit1", "Planificacion", new {id=0})');
                }).then(res => window.location = urlPlanifAddEdit1);
            }
        });

    } else {
        return swalShowError();
    }
}