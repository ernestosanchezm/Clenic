//ACCION DEL BOTON PARA EDITAR EL CONTRATO
$('#btn-editar-muestra').click(function () {
    console.log(muestraSel);
    //console.log(sizeMuestra);
    if ($("#sizeMuestra").val() == '')
        return swalShowWarningMsg("Ingrese cantidad de muestra"); 

    if (parseInt($("#sizeMuestra").val()) <= 0)
        return swalShowWarningMsg("Ingrese cantidad de muestra superior a 0"); 

    $.ajax({
        url: 'Muestra/Edit',
        type: 'post',
        dataType: 'json',
        data: {
            muestraId: muestraSel,
            sizeMuestra: parseInt($('#sizeMuestra').val())
        },
        success: function (data) {
            location.reload();
        }
    });
});

//BOTON PARA ABRIR POPUP DE AGREGAR CONTRATO
$('#btn-registro-muestra-show').click(function () {
    //$('#modCategorias').select2("val", "");
    //$('#modDistritos').select2("val", "");
    //$('#modCanales').select2("val", "");
    //$("#modCanales").select2();
    $("#modCategorias").val(null).trigger("change");
    $("#modDistritos").val(null).trigger("change");
    $("#modCanales").val(null).trigger("change");
    $('#sizeMuestra-reg').val('');
    $('#registroMuestra').modal('show');
});


$('#btn-registro-muestra-save').on('click', function () {

    if ($("#modCategorias").val() == '')
        return swalShowWarningMsg("Seleccione categoria"); 
    if ($("#modDistritos").val() == '')
        return swalShowWarningMsg("Seleccione distrito");
    if ($("#modCanales").val() == '')
        return swalShowWarningMsg("Seleccione canal"); 
    if ($("#sizeMuestra-reg").val() == '')
        return swalShowWarningMsg("Ingrese cantidad de muestra"); 

    if (parseInt($("#sizeMuestra-reg").val()) <= 0)
        return swalShowWarningMsg("Ingrese cantidad de muestra superior a 0"); 

    let datosFrm = {
        categoriaId: $("#modCategorias").val(),
        ubigeo: $('#modDistritos').val(),
        canalId: $('#modCanales').val(),
        sizeMuestra: parseInt($('#sizeMuestra-reg').val())
    };
    console.log(datosFrm);
    $.ajax({
        //url: 'Muestra/Add',
        url: 'Muestra/Add1',
        type: 'post', 
        dataType: 'json',
        data: datosFrm,
        success: function (data) {
            //console.log(data);
            //location.reload();
            if (data.icon == "error") 
                swalShowErrorMsg(data.text);
            else
                location.reload();
        }
    });

});

$("#btnUploadMuestra").on("click", function (e) {
    e.preventDefault();

    var fileUpload = $("#FileMuestra").get(0);
    //console.log(fileUpload);
    var files = fileUpload.files;
    console.log(files);
    if (files.length == 0) {
        return swalShowWarningMsg("No ha seleccionado ningun archivo");
    }

    Swal.fire({
        title: 'Advertencia!',
        //text: "Si continua, se perdera lo guardado!",
        text: "El archivo a subir debe ser excel y con cabecera(categoria,canal,ubigeo,muestra). Si continua se procesara archivo",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Continuar'
    }).then(result => {
        console.log(result);
        if (result.isConfirmed) {
            fnUploadFileMuestra1();
        }
    });
});

//$("#btnUploadMuestra").on("click", function (e) {
function fnUploadFileMuestra1() {
    //e.preventDefault();

    //var urlMuestra_UploadFileMuestra = $('#Muestra_UploadFileMuestra').data('request-url');
    var urlMuestra_UploadFileMuestra = $('#Muestra_UploadFileMuestra1').data('request-url');
    var formData = new FormData($("#frmUploadFileMuestra")[0]);
    var fileUpload = $("#FileMuestra").get(0);
    //console.log(fileUpload);
    var files = fileUpload.files;
    console.log(files);
    if (files.length == 0) {
        return swalShowErrorMsg("No ha seleccionado ningun archivo");
    }

    formData.append(files[0].name, files[0]);
    $.ajax({
        //url: '@Url.Action("UploadFileMuestra", "Muestra")',
        url: urlMuestra_UploadFileMuestra,
        type: 'POST',
        enctype: 'multipart/form-data',
        beforeSend: function () { swalShowLoading(); },
        data: formData,
        error: function () {
            Swal.close();
            /*Swal.fire({
                    title: 'Error!',
                    text: "Ocurió un error inesperado, vuelva a intentar en unos minutos.",
                    icon: 'warning',
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'Continuar'
                });*/
            swalShowErrorMsg("Ocurió un error inesperado, vuelva a intentar en unos minutos.");
        },
        success: function (data) {
            console.log(data)
            Swal.close();
            if (data.statusCode == 200) {
                //location.reload();
                return Swal.fire({
                    icon: 'success',
                    title: 'Correcto'
                }).then(result => {
                    location.reload();
                });
            }
            else if (data.statusCode == 201) {
                swalShowWarningMsg("Revise el archivo excel descargado con las observaciones. ");
                pintarTblMuestraObs(data);
            }
            else {
                swalShowErrorMsg(data.message);
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
//});
}

function pintarTblMuestraObs(data) {

    $("#tblMuestraObs tr").remove();
    //$("#tblMovimiento").addClass("table table-fixed");
    var eTable = "<thead><tr>" +
        "<th>fila</th>" +
        "<th>categoriaId</th>" +
        "<th>canalId</th>" +
        "<th>ubigeo</th>" +
        "<th>muestra</th>" +
        "<th>observacion</th>" +
        "</tr></thead><tbody>";
    for (var i = 0; i < data.result.length; i++) {

        eTable += "<tr>";
        eTable += "<td class='active' x:str="+ data.result[i].id +">" + data.result[i].id + "</td>";
        //eTable += "<td class='active' x:str=" + data.result[i].categoriaId + ">" + data.result[i].categoriaId + "</td>";
        eTable += "<td class='active' x:str=" + data.result[i].scategoriaId + ">" + data.result[i].scategoriaId + "</td>";
        //eTable += "<td class='active' x:str=" + data.result[i].canalId + ">" + data.result[i].canalId + "</td>";
        eTable += "<td class='active' x:str=" + data.result[i].scanalId + ">" + data.result[i].scanalId + "</td>";
        eTable += "<td class='active' x:str=" + data.result[i].ubigeo +">" + data.result[i].ubigeo+ "</td>";
        //eTable += "<td class='active' x:str=" + data.result[i].tamanoMuestra + ">" + data.result[i].tamanoMuestra + "</td>";
        eTable += "<td class='active' x:str=" + data.result[i].stamanoMuestra + ">" + data.result[i].stamanoMuestra + "</td>";

        eTable += "<td>" + data.result[i].obs + "</td>";
        eTable += "</tr>";
    }

    eTable += "</tbody></table>";
    $('#tblMuestraObs').html(eTable);

    ExpTblMuestraObs();
    //ExpTblMuestraObs1();
}

function ExpTblMuestraObs() {

    var nFilaas = $("#tblMuestraObs tr").length;
    var msga = nFilaas - 1;
    console.log(" total muestrObs :  " + msga);

    var uri = 'data:application/vnd.ms-excel;base64,';
    //var uri = 'data:text/vnd.ms-excel;base64,';
    var template = '<html  xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="Content-Type" content="text/html; charset=utf-8"/></head><body><table>{table}</table></body></html>';
    var base64 = function (s) {
        return window.btoa(unescape(encodeURIComponent(s)))
    };
    var format = function (s, c) {
        return s.replace(/{(\w+)}/g, function (m, p) {
            return c[p];
        })
    };
    var ctx = {
        worksheet: 'Muestra',
        table: document.getElementById('tblMuestraObs').innerHTML
    }


    var link = document.createElement("a");
    link.download = "MuestraObservacion.xls";
    link.href = uri + base64(format(template, ctx));
    link.click();
}

function ExpTblMuestraObs1() {

    var nFilaas = $("#tblMuestraObs tr").length;
    var msga = nFilaas - 1;
    console.log(" total muestrObs :  " + msga);

    var uri = 'data:application/vnd.ms-excel;base64,';
    var template = '<html  xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="Content-Type" content="text/html; charset=utf-8"/></head><body><table>{table}</table></body></html>';
    var base64 = function (s) {
        return window.btoa(unescape(encodeURIComponent(s)))
    };
    var format = function (s, c) {
        return s.replace(/{(\w+)}/g, function (m, p) {
            return c[p];
        })
    };
    var ctx = {
        worksheet: 'Muestra',
        table: document.getElementById('tblMuestraObs').innerHTML
    }


    var str = base64(format(template, ctx));
    var blob = b64toBlob(str, "application/vnd.ms-excel");
    var blobUrl = URL.createObjectURL(blob);
    //window.location = blobUrl;

    var a = document.createElement("a");
    a.href = blobUrl;
    a.download = "MuestraObservacion1.xls";
    a.click();
    window.URL.revokeObjectURL(blobUrl);
}