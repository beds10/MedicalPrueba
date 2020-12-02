
pagos = [];
function procesar() {
    const formulario = document.forms['pagoForm'];
    const pago = {
        "cantidad": formulario.elements[0].value
    };

    pagos.push(pago);
    formulario.reset();
    formulario.elements[0].focus();
    console.log(pagos);
}