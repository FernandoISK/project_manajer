var Commentary = {
    init: function () {
        $("#formcommentaryIncidents").on("submit", function (e) {
            e.preventDefault()

            var Mensaje = $("#mensaje").val();
            var IDInci = $("#idincidencia").val();
            var Folio = $("#folio").val();

            if (Mensaje.trim() == "") {
                Dialog.show("Nada que enviar", Dialog.type.error);
                return;
            } if (IDInci.trim() == "") {
                Dialog.show("Error Fatal, recargue la pagina", Dialog.type.error);
                return;
            } if (Folio.trim() == "") {
                Dialog.show("Error Fatal, recargue la pagina", Dialog.type.error);
                return;
            }
            $.ajax({
                url: Root + "RolEmpleado/NewComIncidencia",
                type: "POST",
                data: { comentario: Mensaje, idinci: IDInci, proyecto: Folio },
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