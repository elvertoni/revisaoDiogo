import { Component } from "@angular/core";
import { Genero } from "src/app/models/generoModel";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-listargenero",
  templateUrl: "./listargenero.component.html",
  styleUrls: ["./listargenero.component.css"],
})
export class ListargeneroComponent {
  generos: Genero[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http
      .get<Genero[]>("https://localhost:7220/api/genero/listar")
      .subscribe({
        next: (generos) => {
          this.generos = generos;
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}
