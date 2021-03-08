var GlobalClientes = {
    Objects: {
        ID: 0
    },
    init: function () {
        $("[data-toggle=biometric-select]").on("change", function () {
            var TargetResult = $(this).data("target");
            var Element = this;
            if (Element.value.toString().toLowerCase().includes("jpg") || Element.value.toString().toLowerCase().includes("jpeg")) {
                GlobalClientes.evts.parseFileFromElement(Element, function (e) {
                    $(TargetResult).html("<img src=\"" + e.target.result + "\" class=\"img-fluid\">");
                });
            }
            //this.value = null;
        });
        $("[data-toggle=biometric-clear]").on("click", function () {
            var Target = $(this).data("target");
            var Button = this;
            if ($(Target).find("img").length) {
                $(Target).html(null);
                $(Button).parent().find("input[type=file]").val(null);
            }
        });
        $("#frmCreate").on("submit", function (e) {
            e.preventDefault()
            //debugger
            var ImgAct = false;
            var thumb = $("#face-box").find("img").length > 0 ? $("#face-box").find("img").attr("src") : null;
            if (thumb != null) {
                if (thumb.toString().includes("base64")) {
                    var SplitSrc = thumb.toString().split("base64,");
                    thumb = SplitSrc[1];
                    ImgAct = true;
                }
            }

            var I_Titulo = $("#txtTitulo").val();
            var I_Descripcion = $("#mensaje").val();
            var I_Proyecto = $("#cmbProyecto").val();
            var T_TipoProceso = $("#txtTipoProceso").val();

            if (I_Titulo.trim() == "") {
                Dialog.show("El Campo 'Titulo' es obligatorio", Dialog.type.error);
                return;
            }
            if (I_Descripcion.trim() == "") {
                Dialog.show("El Campo 'Descripcion' es obligatorio", Dialog.type.error);
                return;
            }

            if (thumb != null) {
                if (ImgAct == false) {
                    thumb = null;
                }
            }
            var Agregar = {
                FKProyecto: I_Proyecto,
                Titulo: I_Titulo,
                Descripcion: I_Descripcion,
                Imagen: thumb
            };
            if (T_TipoProceso.trim() == "Requisito") {
                $.ajax({
                    url: Root + "RolCliente/NewRequisito",
                    type: "POST",
                    data: { DatosRequisitos: JSON.stringify(Agregar) },
                    beforeSend: function () {
                        Dialog.show("Registrando", Dialog.type.progress);
                    },
                    success: function (response) {
                        console.log(response);
                        if (response == 1) {
                            Dialog.show("Guardado correctamente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al guardar los datos, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });

            }
            else if (T_TipoProceso.trim() == "Incidencia") {
                $.ajax({
                    url: Root + "RolCliente/NewInsidencia",
                    type: "POST",
                    data: { DatosIncidencia: JSON.stringify(Agregar) },
                    beforeSend: function () {
                        Dialog.show("Registrando", Dialog.type.progress);
                    },
                    success: function (response) {
                        console.log(response);
                        if (response == 1) {
                            Dialog.show("Guardado correctamente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al guardar los datos, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            }
            
        });
        //$(".input-number").on("input", function () {
        //    this.value = this.value.replace(/[^0-9]/g, '');
        //});
    },
    evts: {
        parseFileFromElement: function (Element, Callback) {
            if (Element.files && Element.files[0]) {
                var FR = new FileReader();
                FR.addEventListener("load", function (e) {
                    //document.getElementById("img").src = e.target.result;
                    Callback(e);
                });
                FR.readAsDataURL(Element.files[0]);
            }
        },
        CreateIndidencia: function (id) {
            PropTask.Objects.Folio = id;
            $("#mdlDetail").modal("show");
            Dialog.hide();
        }
    }
}