$(document).ready(function () {
    //alert("dd");
    //var $j = jQuery.noConflict();
    //$j('.openpopup').magnificPopup({ type: 'inline', midClick: true });
   // alert("df");
    $('#calendarionew').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,basicWeek,basicDay'
        },
        defaultDate: '2015-04-12',
        editable: true,
        eventLimit: true, // allow "more" link when too many events
        events: [
            {
                title: 'All Day Event',
                start: '2015-04-01'
            },
            {
                title: 'Long Event',
                start: '2015-04-07',
                end: '2015-04-10'
            },
            {
                id: 999,
                title: 'Repeating Event',
                start: '2015-04-09T16:00:00'
            },
            {
                id: 999,
                title: 'Repeating Event',
                start: '2015-04-16T16:00:00'
            },
            {
                title: 'Conference',
                start: '2015-04-11',
                end: '2015-04-13'
            },
            {
                title: 'Meeting',
                start: '2015-04-12T10:30:00',
                end: '2015-04-12T12:30:00'
            },
            {
                title: 'Lunch',
                start: '2015-04-12T12:00:00'
            },
            {
                title: 'Meeting',
                start: '2015-04-12T14:30:00'
            },
            {
                title: 'Happy Hour',
                start: '2015-04-12T17:30:00'
            },
            {
                title: 'Dinner',
                start: '2015-04-12T20:00:00'
            },
            {
                title: 'Birthday Party',
                start: '2015-04-13T07:00:00'
            },
            {
                title: 'Click for Google',
                url: 'http://google.com/',
                start: '2015-04-28'
            }
        ]
    });
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
$(function () {
    $("#dialog").dialog({
        modal:true,
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        }
    });

});
$(function () {
    $("#dialog-confirm").dialog({
        resizable: false,
        height: 140,
        modal: true,
        autoOpen: false,
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close");
                
            },
            Cancel: function () {
                $(this).dialog("close");
               
            }
        }
    });
});
function validarform() {
    if ($("#cboclientes").val() == "0") { $("#dialog p").text("Ingresar Cliente"); $("#dialog").dialog("open"); return false; }
    if ($("#datepicker").val() == "") { $("#dialog p").text("Ingresar Fecha Servicio"); $("#dialog").dialog("open"); return false; }
    if ($("#cbotiposervicio").val() == "0") { $("#dialog p").text("Ingresar Tipo Servicio"); $("#dialog").dialog("open"); return false; }

   // $("#dialog-confirm").dialog("open");
    return true;
    
    
   
}
