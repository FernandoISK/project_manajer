var Commentary = {
    init: function () {
        $("#formcommentaryRequisito").on("submit", function (e) {
            e.preventDefault()

            var Mensaje = $("#mensaje").val();
            var IDRequi = $("#idrequisito").val();
            var Folio = $("#folio").val();

            if (Mensaje.trim() == "") {
                Dialog.show("Nada que enviar", Dialog.type.error);
                return;
            } if (IDRequi.trim() == "") {
                Dialog.show("Error Fatal, recargue la pagina", Dialog.type.error);
                return;
            } if (Folio.trim() == "") {
                Dialog.show("Error Fatal, recargue la pagina", Dialog.type.error);
                return;
            }
            $.ajax({
                url: Root + "RolEmpleado/NewComRequisito",
                type: "POST",
                data: { comentario: Mensaje, idrequi: IDRequi, proyecto: Folio },
                beforeSend: function () {
                },
                success: function (response) {
                    if (response > 0) {
                        location.reload(true);
                    }
                    else {
                        Dialog.show("Fallo Fatal", Dialog.type.error);
                    }
                }
            });
        });
    },
}