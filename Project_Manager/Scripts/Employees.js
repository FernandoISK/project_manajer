var Employees = {
    Objects: {
        IDEmpleado: 0
    },
    evts: {
        updateStatus: function (id, status) {
            if (status == "1") {
                Dialog.show("Estás seguro que quiere Eliminar este empleaado?", Dialog.type.question);
            }
            else {
                Dialog.show("Reactivar este producto?", Dialog.type.question);
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