import { Autor } from "./Autor.js";
import { Iznajmljivanja } from "./Iznajmljivanja.js";
import { Knjiga } from "./Knjiga.js";
export class Biblioteka {
    constructor(id, naziv, adresa, knjige, listaAutora, listaClanova) {
        this.id = id;
        this.naziv = naziv;
        this.adresa = adresa;
        this.knjige = knjige;
        this.listaAutora = listaAutora;
        this.listaClanova = listaClanova;
        this.kont = null;

    }
    crtaj(host) {

        this.kont = document.createElement("div");
        this.kont.className = "GlavniKontejner";
        host.appendChild(this.kont);

        let naziv = document.createElement("div");
        naziv.className = "divNazivBibl";
        this.kont.appendChild(naziv);

        let l = document.createElement("label");
        l.className = "labelaNazivBibl";
        l.innerHTML = "Biblioteka: " + " " + this.naziv + "<br>" + "Adresa: " + this.adresa;;
        naziv.appendChild(l);

        let el = document.createElement("div");
        el.className = "formaItabela";
        this.kont.appendChild(el);
        this.crtajFormu(el);
        this.crtajPrikazKnjige(el);

    }

    //PRIKAZ TABELE SA KNJIGAMA
    crtajPrikazKnjige(host) {
        let kontPrikaz = document.createElement("div");
        kontPrikaz.className = "Prikaz";
        host.appendChild(kontPrikaz);

        let kontPrikazKnjige = document.createElement("div");
        kontPrikazKnjige.className = "PrikazKnjige";
        kontPrikaz.appendChild(kontPrikazKnjige);

        var tabela = document.createElement("table");
        tabela.className = "tabela";
        kontPrikazKnjige.appendChild(tabela);

        var tabelahead = document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className = "TabelaPodaci";
        tabela.appendChild(tabelaBody);

        let th;
        var zag = ["Naziv knjige", "Autor", "Godina izdanja", "Broj strana"];
        zag.forEach(el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })
        this.knjige.forEach(p => {
            let imePrezime = p.autorKnjige.ime + " " + p.autorKnjige.prezime;
            let knjiga = new Knjiga(p.id, p.naziv, p.godina, p.brojStrana, imePrezime);
            knjiga.crtaj(tabelaBody);
        })


    }
    crtajPrikazKnjige2(host) {
        this.knjige.forEach(p => {
            let imePrezime = p.autorKnjige.ime + " " + p.autorKnjige.prezime;
            let knjiga = new Knjiga(p.id, p.naziv, p.godina, p.brojStrana, imePrezime);
            knjiga.crtaj(host);
        })
    }
    crtajPrikazIznajmljivanje() {
        //PRIKAZ IZNAJMLJIVANJA
        let kontPrikaz = this.kont.querySelector(".Prikaz");

        let kontPrikazIzn = document.createElement("div");
        kontPrikazIzn.className = "PrikazIznajmljivanja";
        kontPrikaz.appendChild(kontPrikazIzn);


        var tabela = document.createElement("table");
        tabela.className = "tabela";
        kontPrikazIzn.appendChild(tabela);

        var tabelahead = document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className = "TabelaPodaciIznajm";
        tabela.appendChild(tabelaBody);

        let th;
        var zag = ["Knjiga", "Datum iznajmljivanja"];
        zag.forEach(el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })


    }

    crtajFormu(host) {
        let kontForma = document.createElement("div");
        kontForma.className = "Forma";
        host.appendChild(kontForma);

        //FORMA KNJIGA
        let formaKnjiga = document.createElement("div");
        formaKnjiga.className = "formaKnjiga";
        kontForma.appendChild(formaKnjiga);
        let l = document.createElement("label");
        l.innerHTML = "Naziv: ";
        formaKnjiga.appendChild(l);
        let el = document.createElement("input");
        el.className = "nazivKnjiga";
        el.type = "text";
        formaKnjiga.appendChild(el);

        l = document.createElement("label");
        l.innerHTML = "Broj strana:";
        formaKnjiga.appendChild(l);
        el = document.createElement("input");
        el.className = "brStrana";
        el.type = "number";
        formaKnjiga.appendChild(el);

        l = document.createElement("label");
        l.innerHTML = "Godina izdanja:";
        formaKnjiga.appendChild(l);
        el = document.createElement("input");
        el.className = "godinaIzdanja";
        el.type = "number";
        formaKnjiga.appendChild(el);

        l = document.createElement("label");
        l.innerHTML = "Autor:";
        formaKnjiga.appendChild(l);
        el = document.createElement("select");
        el.className = "autorKnjiga";
        let op;
        this.listaAutora.forEach(p => {
            op = document.createElement("option");
            op.innerHTML = p.ime + " " + p.prezime;
            op.value = p.id;
            el.appendChild(op);
        });

        formaKnjiga.appendChild(el);
        let divDugmici = document.createElement("div");
        divDugmici.className = "dugmiciKnjiga";
        formaKnjiga.appendChild(divDugmici);

        let btnDodaj = document.createElement("button");
        btnDodaj.innerHTML = "Dodaj knjigu";
        btnDodaj.className = "knjigaDugme";
        divDugmici.appendChild(btnDodaj);
        btnDodaj.onclick = (ev) => this.dodajKnjigu();


        let obrisiKnjigu = document.createElement("button");
        obrisiKnjigu.innerHTML = "Obrisi knjigu";
        obrisiKnjigu.className = "knjigaDugme";
        obrisiKnjigu.onclick = (ev) => this.obrisiKnjigu();
        divDugmici.appendChild(obrisiKnjigu);

        //FORMA CLAN
        let formaClan = document.createElement("div");
        formaClan.className = "formaClan";
        kontForma.appendChild(formaClan);
        l = document.createElement("label");
        l.innerHTML = "Ime:";
        formaClan.appendChild(l);
        el = document.createElement("input");
        el.className = "imeClana";
        formaClan.appendChild(el);

        l = document.createElement("label");
        l.innerHTML = "Prezime:";
        formaClan.appendChild(l);
        el = document.createElement("input");
        el.className = "prezimeClana";
        formaClan.appendChild(el);

        l = document.createElement("label");
        l.innerHTML = "JMBG:";
        formaClan.appendChild(l);
        el = document.createElement("input");
        el.type = "number";
        el.className = "JMBGClana";
        formaClan.appendChild(el);

        divDugmici = document.createElement("div");
        divDugmici.className = "dugmiciClan";
        formaClan.appendChild(divDugmici);
        let dodajClana = document.createElement("button");
        dodajClana.innerHTML = "Dodaj clana";
        dodajClana.className = "clanDugme";
        dodajClana.onclick = (ev) => this.dodajClana();
        divDugmici.appendChild(dodajClana);

        let izmeniClana = document.createElement("button");
        izmeniClana.innerHTML = "Izmeni clana";
        izmeniClana.className = "clanDugme";
        izmeniClana.onclick = (ev) => this.izmeniClana();
        divDugmici.appendChild(izmeniClana);


        //FORMA IZNAJMI KNJIGU
        let formaIznajmi = document.createElement("div");
        formaIznajmi.className = "formaIznajmi";
        kontForma.appendChild(formaIznajmi);
        l = document.createElement("label");
        l.innerHTML = "Clan:";
        formaIznajmi.appendChild(l);
        el = document.createElement("select");
        el.className = "clanIznajm"

        this.listaClanova.forEach(p => {
            op = document.createElement("option");
            op.innerHTML = p.ime + " " + p.prezime;
            op.value = p.id;
            el.appendChild(op);
        });
        formaIznajmi.appendChild(el);

        l = document.createElement("label");
        l.innerHTML = "Knjiga:";
        formaIznajmi.appendChild(l);
        el = document.createElement("select");
        el.className = "knjigaIznajm"
        this.knjige.forEach(p => {
            op = document.createElement("option");
            op.innerHTML = p.naziv;
            op.value = p.id;
            el.appendChild(op);
        });

        formaIznajmi.appendChild(el);

        l = document.createElement("label");
        l.innerHTML = "Datum:";
        formaIznajmi.appendChild(l);
        el = document.createElement("input");
        el.type = "date";
        el.className = "datumIznajm";
        formaIznajmi.appendChild(el);

        el = document.createElement("button");
        el.innerHTML = "Iznajmi knjigu";
        el.onclick = (ev) => this.iznajmiKnjigu();
        formaIznajmi.appendChild(el);
    }
    dodajKnjigu() {
        const nazivKnjige = this.kont.querySelector(".nazivKnjiga").value;
        const brojStrana = this.kont.querySelector(".brStrana").value;
        const godinaIzdanja = this.kont.querySelector(".godinaIzdanja").value;

        const autorID = this.kont.querySelector('option:checked').value;
        const autorImePrezime = this.kont.querySelector('option:checked').textContent.split(" ");
        const autorIme = autorImePrezime[0];
        const autorPrezime = autorImePrezime[1];
        const autor = new Autor(autorID, autorIme, autorPrezime);

        if (nazivKnjige === "") {
            alert("Molim Vas unesite naziv knjige!");
            return;
        } else if (brojStrana === "") {
            alert("Molim Vas unesite broj strana!");
            return;
        } else if (parseInt(brojStrana) < 20 || parseInt(brojStrana) > 2000) {
            alert("Broj strana mora biti veci od 20 a manji od 2000!");
            return;
        } else if (godinaIzdanja === "") {
            alert("Molim Vas unesite godinu izdanja!");
            return;
        }

        fetch("https://localhost:5001/Knjiga/DodajKnjigu/" + this.id, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "naziv": nazivKnjige,
                "godina": godinaIzdanja,
                "brojStrana": brojStrana,
                "autorKnjige": autor
            })
        }).then(p => {
            if (p.ok) {
                alert("Knjiga je uspesno dodata!");
                this.osveziPrikazKnjiga();
            } else {
                alert("Nastala je greska prilikom dodavanja knjige! Proverite da li knjiga sa tim nazivom vec ne postoji u biblioteci!");

            }
        })


    }

    obrisiKnjigu() {
        const nazivKnjige = this.kont.querySelector(".nazivKnjiga").value;
        if (nazivKnjige === "") {
            alert("Unesite naziv knjige koju zelite da obrisete!");
            return;
        }
        fetch("https://localhost:5001/Knjiga/ObrisiKnjigu/" + nazivKnjige, {
            method: "DELETE"

        }).then(p => {
            if (p.ok) {
                alert("Knjiga je uspesno obrisana!");
                this.osveziPrikazKnjiga();

            } else {
                alert("Ne mozete obrisati knjigu koja ne postoji ili je iznajmljena od strane nekog korisnika!");

            }
        })
    }
    dodajClana() {
        const imeClana = this.kont.querySelector(".imeClana").value;
        const prezimeClana = this.kont.querySelector(".prezimeClana").value;
        const JMBGClana = this.kont.querySelector(".JMBGClana").value;
        if (imeClana === "") {
            alert("Molim Vas unesite ime clana!");
            return;
        } else if (prezimeClana === "") {
            alert("Molim Vas unesite prezime clana!");
            return;
        } else if (JMBGClana === "") {
            alert("Molim Vas unesite JMBG clana!");
            return;
        } else if (JMBGClana.length != 13) {
            alert("JMBG mora da ima 13 cifara!");
            return;
        }

        fetch("https://localhost:5001/Clan/DodajClana/" + this.id, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "JMBG": JMBGClana,
                "ime": imeClana,
                "prezime": prezimeClana
            })
        }).then(p => {
            if (p.ok) {
                alert("Clan je uspesno dodat!");
                this.osveziPrikazClan();
            } else {
                alert("Nastala je greska prilikom dodavanja clana!");

            }
        })
    }
    izmeniClana() {
        const imeClana = this.kont.querySelector(".imeClana").value;
        const prezimeClana = this.kont.querySelector(".prezimeClana").value;
        const JMBGClana = this.kont.querySelector(".JMBGClana").value;

        if (imeClana === "") {
            alert("Molim Vas unesite ime clana!");
            return;
        } else if (prezimeClana === "") {
            alert("Molim Vas unesite prezime clana!");
            return;
        } else if (JMBGClana === "") {
            alert("Molim Vas unesite JMBG clana!");
            return;
        } else if (JMBGClana.length != 13) {
            alert("JMBG mora da ima 13 cifara!");
            return;
        }

        fetch("https://localhost:5001/Clan/IzmeniClana", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "JMBG": JMBGClana,
                "ime": imeClana,
                "prezime": prezimeClana
            })
        }).then(s => {
            if (s.ok) {
                alert("Clan sa jmbg-om: " + JMBGClana + " je uspesno promenjen!");
                this.osveziPrikazClan();
            } else {
                alert("Nastala je greska prilikom izmene clana!");

            }
        })

    }
    iznajmiKnjigu() {

        let selectClan = this.kont.querySelector(".clanIznajm");
        let clan = this.kont.querySelector(".clanIznajm").options[selectClan.selectedIndex].text.split(" ");
        let clanObj = this.listaClanova.find(obj => {
            return obj.ime === clan[0] || obj.prezime === clan[1];
        })
        let clanID = clanObj.id;


        let selectKnjiga = this.kont.querySelector(".knjigaIznajm");
        let knjiga = selectKnjiga.options[selectKnjiga.selectedIndex].text;
        let knjigaObj = this.knjige.find(obj => {
            return obj.naziv === knjiga;
        })
        let knjigaID = knjigaObj.id;

        const datum = this.kont.querySelector(".datumIznajm").value;
        if (datum === "") {
            alert("Molim Vas izaberite datum!");
            return;
        }

        fetch("https://localhost:5001/Iznajmljivanje/DodajIznajmljivanje/" + datum + "/" + clanID + "/" + knjigaID, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        }).then(p => {
            if (p.ok) {
                alert("Knjiga je uspesno iznajmljena!");
                if (this.kont.querySelector(".TabelaPodaciIznajm") != null) {
                    this.obrisiIznajmljivanja();

                } else {
                    this.crtajPrikazIznajmljivanje();
                }


                fetch("https://localhost:5001/Iznajmljivanje/PreuzmiIznajmljivanja/" + clanID, {
                    method: "GET",
                }).then(s => {
                    if (s.ok) {
                        s.json().then(data => {
                            data.forEach(el => {
                                let imePrezime = el.clan.ime + " " + el.clan.prezime;
                                let knjiga = el.knjige.naziv;
                                let iznajmljivanje = new Iznajmljivanja(imePrezime, knjiga, el.datum);

                                let tabela = this.kont.querySelector(".TabelaPodaciIznajm");

                                iznajmljivanje.crtaj(tabela);

                            })
                        })
                    } else {
                        alert("Nastala je greska prilikom iznajmljivanja knjige!");

                    }
                })

            } else {
                alert("Clan je vec iznajmio tu knjigu!");

            }
        })


    }

    obrisiPrethodniSadrzaj() {
        var bodyTable = this.kont.querySelector(".TabelaPodaci");
        var roditelj = bodyTable.parentNode;
        roditelj.removeChild(bodyTable);

        bodyTable = document.createElement("tbody");
        bodyTable.className = "TabelaPodaci";
        roditelj.appendChild(bodyTable);
        return bodyTable;
    }

    obrisiIznajmljivanja() {
        var bodyTable = this.kont.querySelector(".TabelaPodaciIznajm");
        var roditelj = bodyTable.parentNode;
        roditelj.removeChild(bodyTable);

        bodyTable = document.createElement("tbody");
        bodyTable.className = "TabelaPodaciIznajm";
        roditelj.appendChild(bodyTable);
        return bodyTable;
    }

    osveziPrikazKnjiga() {

        fetch("https://localhost:5001/Biblioteka/PreuzmiBiblioteku/" + this.id)
            .then(p => {
                p.json().then(biblioteka => {
                    this.knjige = biblioteka.knjige;
                    var tabela = this.obrisiPrethodniSadrzaj();
                    this.crtajPrikazKnjige2(tabela);
                    this.updateKnjige(this.kont.querySelector(".knjigaIznajm"))
                })
            })
    }
    osveziPrikazClan() {
        fetch("https://localhost:5001/Biblioteka/PreuzmiBiblioteku/" + this.id)
            .then(p => {
                p.json().then(biblioteka => {
                    this.listaClanova = biblioteka.clanovi;
                    this.updateClana(this.kont.querySelector(".clanIznajm"))
                })
            })
    }
    updateClana(selectClan) {
        var length = selectClan.options.length;
        for (let i = length; i >= 0; i--)
            selectClan.options[i] = null;

        let op;
        this.listaClanova.forEach(p => {
            op = document.createElement("option");
            op.innerHTML = p.ime + " " + p.prezime;
            op.value = p.id;
            selectClan.appendChild(op);
        });
    }
    updateKnjige(selectKnjige) {
        var length = selectKnjige.options.length;
        for (let i = length; i >= 0; i--)
            selectKnjige.options[i] = null;

        let op;
        this.knjige.forEach(p => {
            op = document.createElement("option");
            op.innerHTML = p.naziv;
            op.value = p.id;
            selectKnjige.appendChild(op);
        });

    }
}