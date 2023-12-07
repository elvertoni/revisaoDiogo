import { Genero } from "./generoModel";

export interface Livro {
  livroId?: number;
  titulo: string;
  descricao: string;
  criadoEm?: string;
  preco: number;
  quantidade: number;
  generoId: number;
  genero?: Genero;
}
