export class Knjiga {
    constructor(id, naziv, godina, brStrana, autori) {
        this.id = id;
        this.naziv = naziv;
        this.godina = godina;
        this.brStrana = brStrana;
        this.autori = autori;
    }

    crtaj(host) {
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.naziv;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.autori;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.godina;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.brStrana;
        tr.appendChild(el);
    }
}