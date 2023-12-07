import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Genero } from "src/app/models/generoModel";

@Component({
  selector: "app-cadastrargenero",
  templateUrl: "./cadastrargenero.component.html",
  styleUrls: ["./cadastrargenero.component.css"],
})
export class CadastrargeneroComponent {
  constructor(private http: HttpClient, private router: Router) {}

  nome: string = "";

  cadastrarGenero(): void {
    let genero: Genero = {
      nome: this.nome,
    };
    this.http
      .post<Genero>("https://localhost:7220/api/genero/cadastrar", genero)
      .subscribe({
        next: (generos) => {
          this.router.navigate(["/pages/livro/cadastrar"]);
        },
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}
