$(document).ready(function () {
    //alert("dd");
    //var $j = jQuery.noConflict();
    //$j('.openpopup').magnificPopup({ type: 'inline', midClick: true });
  
    $('#aprobarsol').click(function () {
        var studentListVal = null;
        studentListVal = [];

        $('input:checkbox:checked').each(function () {
            studentListVal.push($(this).attr('value'));
        });
        $.ajax({
        url: '/AtenderSolicitud/atenderSolicitudes',
        type: "POST",
        data: { listanros: studentListVal },
        traditional:true,
        success: function (data) {
            
        },
        error: function (xhr, status, error) {
            window.location.href = '/AtenderSolicitud/SolicitudesAprobadas';
           // alert(xhr.responseText);
        }
    });
        });
    $('#rechazarsol').click(function () {

        var soliListVal = null;
        soliListVal = [];

        $('input:checkbox:checked').each(function () {
            soliListVal.push($(this).attr('value'));
        });
        $.ajax({
            url: '/AtenderSolicitud/rechazarSolicitudes',
            type: "POST",
            data: { listanros: soliListVal },
            traditional: true,
            success: function (data) {
                window.location.href = '/AtenderSolicitud/SolicitudesRechazadas';
            },
            error: function (xhr, status, error) {
               // alert(xhr.responseText);
            }
        });
    })
    
    $('#btlistar').click(function () {
        $.ajax({
            url: '/AtenderSolicitud/listarSolicitudes',
            type: "POST",

            data: {opcionlist:$("input[name='opcionlist']:checked").val(), fechaservicio:$("#fechaservicio").val(),tiposervicio:$("#cbotiposervicio").val()},
            cache: false,
            success: function (data) {
                // alert(data);
                //Fill div with results
                $("#listsolicitudes").html(data);
               // dialog.dialog("close");
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    });
    
    $('#agreite').click(function () {
       
        //var DTO = {
        //    Name: $('#Name').val()
        //};
        $.ajax({
            url: '/SolicitudProgramacion/CargarIti',
            type: "POST",
    
            data: $("#formitinerario").serializeArray(),
            traditional: true,
            success: function (data) {
               // alert(data);
                //Fill div with results
                $("#listitinerario").html(data);
                dialog.dialog("close");
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    });
    dialog = $("#dialog-form").dialog({
        autoOpen: false,
        height: 500,
        width: 330,
        modal: true

    });
    $("#agregar-iti").button().on("click", function () {

        dialog.dialog("open");
    });

   
});
$(function () {
    $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#datepickeriti").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#fechaservicio").datepicker({ dateFormat: 'dd-mm-yy' });
   
});