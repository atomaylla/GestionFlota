$(document).ready(function () {

    var data = kendo.observable({
        radio: "fecha_servicio"
    });
    kendo.bind($("#example"), data);

    var date = new Date();    
    var yyyy = date.getFullYear().toString();
    var mm = (date.getMonth() + 1).toString();
    var dd = date.getDate().toString();

    var parametros = { "fecha": yyyy+'/'+mm+'/'+dd, "tipoServicio": 0, "option": "fecha_servicio"};

        $.ajax({
            url: '/PlanificacionProgramacion/ListSolicitudes',
            type: "Post",
            data: parametros,
            dataType: 'json',
            success: function (result) {
               
            var list =result                                   

                $("#gridSolicitudes").kendoGrid({
                    dataSource: {
                        type: "json",
                        pageSize: 10,
                        groupable: true,
                        selectable: "row",
                        data: list,
                    },
                   
                    scrollable: true,
                    sortable: true,
                    pageable: true,
                    columns: [
                        
                        { field: "nroSolicitud", title: "# Solicitud", width: 60},
                        { field: "fechaServicio", title: "Fecha Servicio", width: 60, type: "date", format: "{0:dd-MM-yyyy}" },
                        { field: "razonCliente", title: "Cliente", width: 100 },
                        { field: "nomTipoServicio", title: "Tipo Servicio", width: 50 },                         
                        { command: { name: "", text: "Planificar Programación", click: showDetails }, title: "", width: "90px" },
                      
                    ] 
                                                            
                });         
              
            }
        });
     
      function showDetails(e) {
      	  e.preventDefault();
          var dataItem = this.dataItem($(e.target).closest("tr"));                                                                             
          window.location.href = '/myaction/Edit'+'?id='+dataItem.Codigo;
       
      }

      $("#btnSearch").click(function (event) {

          

              var _fecha = $("#fecha").val();
              var _tipoServicio = $("#tipoServicio").val();
              var _option = $('#radio:checked').val();
         
              var parametros = { "fecha": _fecha, "tipoServicio": _tipoServicio, "option": _option };


              $.ajax({
                  url: '/PlanificacionProgramacion/ListSolicitudes',
                  type: "Post",
                  dataType: 'json',
                  data: parametros,
                  success: function (result) {

                      var list = result

                      $("#gridSolicitudes").kendoGrid({
                          dataSource: {
                              type: "json",                              
                              pageSize: 10,
                              groupable: true,
                              selectable: "row",
                              data: list,
                          },

                          scrollable: true,
                          sortable: true,
                          pageable: true,
                          columns: [

                              { field: "nroSolicitud", title: "# Solicitud", width: 60 },
                              { field: "fechaServicio", title: "Fecha Servicio", width: 60, type: "date", format: "{0:dd-MM-yyyy}" },
                              { field: "razonCliente", title: "Cliente", width: 100 },
                              { field: "nomTipoServicio", title: "Tipo Servicio", width: 90 },
                              { command: { name: "", text: "Planificar", click: showDetails }, title: "", width: "45px" },

                          ]

                      });

                  }
              });

          }
      );

 });