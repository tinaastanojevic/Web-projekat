import { Autor } from "./Autor.js";
import { Biblioteka } from "./Biblioteka.js";

var listaAutora = [];

fetch("https://localhost:5001/Autor/PreuzmiAutore")
    .then(p => {
        p.json().then(autori => {
            autori.forEach(autor => {
                var a = new Autor(autor.id, autor.ime, autor.prezime);
                listaAutora.push(a);
            });

            fetch("https://localhost:5001/Biblioteka/PreuzmiBiblioteke")
                .then(p => {
                    p.json().then(biblioteke => {
                        biblioteke.forEach(biblioteka => {

                            var a = new Biblioteka(biblioteka.id, biblioteka.naziv, biblioteka.adresa, biblioteka.knjige, listaAutora, biblioteka.clanovi);
                            a.crtaj(document.body);
                        });
                    })
                })
        })
    })