
    setInterval("odswiez();", 1000);

function odswiez() {
        
    // Nazwy miesięcy
    var nazwy_mies = ['January', 'February', 'March', 'April', 'May',
        'June', 'July', 'August', 'September', 'October',
        'November', 'December'];

    // Odczytanie bieżącej daty i czasu, i rozbicie ich na składowe
    var data = new Date();
    var rok = data.getFullYear();
    var mies = data.getMonth();
    var dzien = data.getDate();
    var godz = data.getHours();
    var min = data.getMinutes();
    var sec = data.getSeconds();

    // Dodanie zera na początku minut i sekund jeżeli trzeba
    if (godz < 10)
        godz = '0' + godz;
    if (min < 10)
        min = '0' + min;
    if (sec < 10)
        sec = '0' + sec;

    // Utworzenie odpowiednio sformatowanej daty i czasu
    var data_i_czas = dzien + ' ' + nazwy_mies[mies] + ' ' + rok
        + ', ' + godz + ':' + min + ':' + sec;
    var lala = data_i_czas;
        
    document.getElementById('czas').innerHTML = data_i_czas;
}

