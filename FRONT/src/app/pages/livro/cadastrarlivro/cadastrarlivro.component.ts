import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Genero } from 'src/app/models/generoModel';
import { Livro } from 'src/app/models/livroModel';

@Component({
  selector: 'app-cadastrarlivro',
  templateUrl: './cadastrarlivro.component.html',
  styleUrls: ['./cadastrarlivro.component.css']
})
export class CadastrarlivroComponent {

  constructor(private http: HttpClient, private router: Router) {}

  titulo: string = "";
  descricao: string = "";
  preco: number = 0;
  quantidade: number = 0;
  generoId: number = 0;
  generos?: Genero [] = [];

  ngOnInit(): void {
    this.http.get<Genero[]>("https://localhost:7220/api/genero/listar").subscribe({
      next: (generos) => {
        this.generos = generos;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }

  cadastrar() : void {
    let livro: Livro = {
      titulo: this.titulo,
      descricao: this.descricao,
      preco: this.preco,
      quantidade: this.quantidade,
      generoId: this.generoId
    };
    this.http.post<Livro>("https://localhost:7220/api/livro/cadastrar", livro).subscribe({
      next: (livros) => {
        this.router.navigate(["/pages/livro/cadastrar"]);
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }

}
