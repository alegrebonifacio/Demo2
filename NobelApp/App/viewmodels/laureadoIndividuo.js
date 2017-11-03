define(['durandal/app'], function (app) {
    var ctor = function () {
        console.log('ViewModel initiated...')
        var self = this;
        var baseUri = 'http://localhost:56562/api/LaureadoIndividuos';
        this.displayName = 'Lista de Laureados';
        this.laureadosURI
        //---Variáveis locais
        self.error = ko.observable();
        self.laureates = ko.observableArray();
        //--- Internal functions
        function ajaxHelper(uri, method, data) {
            self.error(''); // Clear error message
            return $.ajax({
                type: method,
                url: uri,
                dataType: 'json',
                contentType: 'application/json',
                data: data ? JSON.stringify(data) : null,
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log("AJAX Call[" + uri + "] Fail...");
                    self.error(errorThrown);
                }
            })
        }
        getLaureates = function () {
            console.log('CALL: getLaureates...')
            ajaxHelper(baseUri, 'GET').done(function (data) {
                self.laureates(data);
                if (self.laureates().length == 0)
                    alert('No Laureates found...');
            });
        };
        start = function () {
            console.log('CALL: start...');
            getLaureates();
        };
        start();
    };

    return ctor;
});