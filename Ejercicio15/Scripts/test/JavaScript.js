describe("A suite", function () {
    it("contains spec with an expectation", function () {
        expect(true).toBe(true);
    });
});

describe("Another suite", function () {
    var resultado;
    it("Prueba de peticion REST", function (done) {
        $.get("api/values/3", function (data) {
            resultado = data;
            done();
        });     
    });
    afterEach(function (done) {
        expect(resultado).toBe("value");
        done();
    }, 1000);
});

describe("Another suite", function () {
    var resultado;
    it("Prueba de peticion REST", function (done) {
        $.get("api/values", function (data) {
            resultado = data;
            done();
        });
    });
    afterEach(function (done) {
        expect(typeof resultado).toBe("object");
        done();
    }, 1000);
});

describe("Llamada POST:", function () {
    var resultado;
    it("Prueba de peticion REST POST", function (done) {
        var parametros = "{}";
        $.post("api/values",parametros, function (data) {
            resultado = data;
            done();
        });
    });
    afterEach(function (done) {
        expect(true).toBe(true);
        done();
    }, 1000);
});

describe("Llamada POST:", function () {
    var resultado;
    it("Prueba de peticion REST PUT", function (done) {
        var parametros = "{}";
        $.ajax({
            type: "PUT",
            url: "api/values/4",
            success: function (result) { done();}
        }
            );
        
    });
    afterEach(function (done) {
        expect(true).toBe(true);
        done();
    }, 1000);
});

describe("Llamada POST:", function () {
    var resultado;
    it("Prueba de peticion REST PUT", function (done) {
        var parametros = "{}";
        $.ajax({
            type: "DELETE",
            url: "api/values/4",
            success: function (result) { done(); }
        }
            );

    });
    afterEach(function (done) {
        expect(true).toBe(true);
        done();
    }, 1000);
});

describe("Llamada POST EntrdasController:", function () {
    var resultado;
    it("Prueba de peticion REST POST", function (done) {
        var params = {Precio:'99'};
        $.post("api/Entradas",params,function(result){
            resultado = result;
            done();
        });

    });
    afterEach(function (done) {
        expect(resultado.Precio == '99').toBe(true);
        done();
    }, 1000);
}); 