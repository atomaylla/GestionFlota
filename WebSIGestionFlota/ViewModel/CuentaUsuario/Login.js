$(document).ready(function () {

        //Login
   var validator = $("#window").kendoValidator().data("kendoValidator");
         
            
    $("#btnAceptar").click(function(event) {
          

        if(validator.validate()){
        
           var _user = $("#user").val();
           var _pass = $("#pass").val();  
           var parametros = { "user": _user, "pass": _pass};

                $.ajax({
                    url: "/CuentaUsuario/Logueo",
                    async: true,
                    type: "Post",
                    data: parametros,
                    dataType: 'json',                                   
                    success: function (result) {
                        if (result.codUsuario>0) {
                            window.location.href ="/Home/Index";
                       }else{
                        alert("Usuario y/o password incorrectos");
                       }                                          
                     }
                });

                  }

            });

});    
