export class Iznajmljivanja {
    constructor(clan, knjiga, datum) {
        this.clan = clan;
        this.knjiga = knjiga;
        this.datum = datum;
    }

    crtaj(host) {
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.knjiga;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.datum;
        tr.appendChild(el);

    }

}