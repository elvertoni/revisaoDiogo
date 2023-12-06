import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ListarlivroComponent } from "./pages/livro/listarlivro/listarlivro.component";
import { ListargeneroComponent } from "./pages/genero/listargenero/listargenero.component";
import { CadastrargeneroComponent } from "./pages/genero/cadastrargenero/cadastrargenero.component";
import { CadastrarlivroComponent } from "./pages/livro/cadastrarlivro/cadastrarlivro.component";

const routes: Routes = [
  {
    path: "",
    component: ListarlivroComponent,
  },
  {
    path: "pages/livro/listar",
    component: ListarlivroComponent,
  },
  {
    path: "pages/livro/cadastrar",
    component: CadastrarlivroComponent,
  },

  {
    path: "pages/genero/listar",
    component: ListargeneroComponent,
  },
  {
    path: "pages/genero/cadastrar",
    component: CadastrargeneroComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
