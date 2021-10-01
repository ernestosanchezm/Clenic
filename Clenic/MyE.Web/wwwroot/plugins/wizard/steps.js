$(".tab-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "fade"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        finish: "Submit"
    }
    , onFinished: function (event, currentIndex) {
        swal("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");

    }
});


var form = $("#formulario").show();

var statusSiguiente = false;

var statusExecApi = 1;  // 1: ejecutar ; 2: ejecutó y va al siguiente 
var statusExecValidPerYFrec = 1;  // 1: ejecutar  , 2: ejecutó y pasa al siguiente
var rptaApi = '';
//.validation - wizard
$("#formulario").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Publicar Encuestas"
    },
    onStepChanging: function (event, currentIndex, newIndex) {

        var valido = currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())
        console.log(String(currentIndex) + '  ' + String(newIndex));
        if (!valido) return 0;

        if (currentIndex == 0) {
            if (currentIndex < newIndex) {
                if (statusExecValidPerYFrec == 2) {
                    statusExecValidPerYFrec = 1;
                    return 1;
                }

                if (statusExecValidPerYFrec == 1) {

                    validPeriodoYFrecuencia()
                        .then(e => {
                            if (e.continua) {
                                statusExecValidPerYFrec = 2;
                                return form.steps("next");
                            } else {
                                var rptaFrec = getFrecuencia() == 'B' ? "Bimestral" : "Mensual";
                                var mensaje = '';
                                if (e.message == 'PE') {
                                    mensaje = 'Ya existe una planificacion con el mismo periodo y frecuencia';
                                } else {
                                    mensaje = 'Existe una planificacion abierta con otro periodo';
                                }
                                statusExecValidPerYFrec = 1;
                                return Swal.fire({
                                    icon: 'warning',
                                    title: mensaje
                                });
                            }
                        });
                    return 0;
                }
            } else if (currentIndex > newIndex) {
                return 1;
            }



            return 1;
        }
        else if (currentIndex == 1) {
            if (currentIndex < newIndex) {
                if (statusExecApi == 2) {
                    statusExecApi = 1;
                    return 1;
                }

                if (statusExecApi == 1) {
                    validarCategoria()
                        .then(res => {
                            console.log(res);
                            rptaApi = res;
                            if (rptaApi) {
                                statusExecApi = 2;
                                return form.steps("next");
                            }
                            else {
                                statusExecApi = 1;
                                return Swal.fire({
                                    icon: 'warning',
                                    title: 'Ya se registro una o mas categorias seleccionadas para este periodo'
                                });
                            }

                        });
                }

                return 0;
            } else if (currentIndex > newIndex) {
                return 1;
            }

        }
        else if (currentIndex == 2) {
            return 1;
            //var res = actTblPlanif();
            //if (res == -1) {
            //    Swal.fire({
            //        icon: 'warning',
            //        title: 'Debe seleccionar almenos un canal en cada categoria'
            //    });
            //    return 0;
            //}
            //else if (res == 1) {

            //    SetTblPlanificacion();
            //    return 1;
            //} else if (res == 0) {
            //    return 1;
            //}
        }
        else {
            return 1;
        }
    },
    onStepChanged: function (event, currentIndex, priorIndex) {
        var todo = $('#btnsave');
        todo.remove();
        if (currentIndex == 1) {
            actCatSel();
        }
        else if (currentIndex == 2) {
            actCanYZonas();
            if (currentIndex > priorIndex) {
                var res = actTblCanales();
                if (res == 1) {
                    //necesita actualizar tabla
                    tblCategoriasYCanales();
                    return 1;
                }
                else if (res == 0) {
                    //No se a modificado las categorias, no necesita actualizar tabla
                    return 1;
                }
            }


        }
        else if (currentIndex == 3) {
            var todo = $('#btnswizard');
            var html = `<li id="btnsave">
                        <a style="background-color:rgb(229, 96, 83);" onclick="SaveEstado()" > Pre-Guardado</a>
                        </li>`;
            todo.append(html);

            if (currentIndex > priorIndex) {
                var res = actTblPlanif();
                if (res == -1) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Debe seleccionar almenos un canal en cada categoria'
                    });
                    return 0;
                }
                else if (res == 1) {

                    SetTblPlanificacion();
                    return 1;
                } else if (res == 0) {
                    return 1;
                }
            }


        }
    },
    onFinishing: function (event, currentIndex) {
        if (form.validate().settings.ignore = ":disabled", form.valid()) {
            return 1;
        } else {
            Swal.fire({
                icon: 'warning',
                title: 'Debe completar los campos obligatorios'
            });
            return 0;
        }
    },
    onFinished: function (event, currentIndex) {
        GenerarEncuestas();
    }
}),
    $(".validation-wizard").validate({
        ignore: "input[type=hidden]"
        , errorClass: "text-danger"
        , successClass: "text-success"
        , highlight: function (element, errorClass) {
            $(element).removeClass(errorClass)
        }
        , unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass)
        }
        , errorPlacement: function (error, element) {
            error.insertAfter(element)
        }
        , rules: {
            email: {
                email: !0
            }
        }
    })