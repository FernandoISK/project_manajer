var Employees = {
    Objects: {
        IDEmpleado: 0
    },
    init: function () {
        $("#frmCreate").on("submit", function (e) {
            e.preventDefault()

            var E_NAME = $("#txtNombre").val();
            var E_PATERNALSURNAME = $("#txtApellidoP").val();
            var E_MATERNALSURNAME = $("#txtApellidoM").val();
            var E_CELLPHONE = $("#txtCelular").val();
            var E_BIRTH = $("#txtfecha").val();
            var E_GENDER = $("#txtGenero").val();
            var E_EMAIL = $("#txtCorreo").val();
            var E_PREPASSWORD = $("#txtPreContraseña").val();
            var E_PASSWORD = $("#txtContraseña").val();
            var E_USERNAME = $("#txtUsuario").val();

            if (E_NAME.trim() == "") {
                Dialog.show("El campo 'Nombre' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_PATERNALSURNAME.trim() == "") {
                Dialog.show("El campo 'Apellido paterno' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_MATERNALSURNAME.trim() == "") {
                Dialog.show("El campo 'Apellido materno es obligatorio' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_CELLPHONE.trim() == "") {
                Dialog.show("El campo 'Telefono' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_BIRTH.trim() == "") {
                Dialog.show("El campo 'Fecha de nacimiento' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_GENDER.trim() == "") {
                Dialog.show("El campo 'Genero' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_EMAIL.trim() == "") {
                Dialog.show("El campo 'Correo electronico' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_USERNAME.trim() == "") {
                Dialog.show("El campo 'Usuario' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_PREPASSWORD.trim() == "") {
                Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                return;
            }
            if (E_PREPASSWORD.trim() != E_PASSWORD.trim()) {
                Dialog.show("La contraseña no coincide", Dialog.type.error);
                return;
            }
                $.ajax({
                    url: Root + "Empleado/New",
                    type: "POST",
                    data: { nombre: E_NAME, apellidop: E_PATERNALSURNAME, apellidom: E_MATERNALSURNAME, telefono: E_CELLPHONE, nacimineto: E_BIRTH, genero: E_GENDER, correo: E_EMAIL, contraseña: E_PASSWORD, usuario: E_USERNAME },
                    beforeSend: function () {
                        Dialog.show("Guardando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nuevo empleado creado correctamente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                                //location.href = '/HumanResources/Persons';
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al guardar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            //else {
            //    $.ajax({
            //        url: Root + "productos/Update",
            //        type: "POST",
            //        data: { costoCred: R_COSTO, nombre: R_NAME, descipcion: R_DESCRIPTION, id: Products.Objects.idProducto },
            //        beforeSend: function () {
            //            Dialog.show("Actualizando datos", Dialog.type.progress);
            //        },
            //        success: function (response) {
            //            if (response > 0) {
            //                Dialog.show("Producto actualizado correctamente", Dialog.type.success);
            //                $(".sem-dialog").on("done", function () {
            //                    location.reload(true);
            //                    //location.href = '/HumanResources/Persons';
            //                });
            //            }
            //            else {
            //                Dialog.show("Ocurrió un error al actualizar, inténtelo de nuevo", Dialog.type.error);
            //            }
            //        }
            //    });
            //}
        });
        $(".input-number").on("input", function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    },
    evts: {
        updateStatus: function (id, status) {
            if (status == "0") {
                Dialog.show("Estás seguro que quiere Eliminar este empleaado?", Dialog.type.question);
            }
            else {
                Dialog.show("Reactivar este Empleado?", Dialog.type.question);
            }
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Empleado/UpdateStatus",
                    type: "POST",
                    data: { id: id, estatus: status },
                    beforeSend: function () {
                        Dialog.show("Eliminando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            location.reload(true);
                        }
                        else {
                            Dialog.show("Ocurrió un error al eliminar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            });
        }
    }
}