import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Livro } from "src/app/models/livroModel";

@Component({
  selector: "app-listarlivro",
  templateUrl: "./listarlivro.component.html",
  styleUrls: ["./listarlivro.component.css"],
})
export class ListarlivroComponent {
  livros: Livro[] = [];
  
  constructor(private http: HttpClient) {}
  
  ngOnInit(): void {
    this.http.get<Livro[]>("https://localhost:7220/api/livro/listar").subscribe({
      next: (livros) => {
        this.livros = livros;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}
