import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListarlivroComponent } from './pages/livro/listarlivro/listarlivro.component';
import { CadastrarlivroComponent } from './pages/livro/cadastrarlivro/cadastrarlivro.component';
import { ListargeneroComponent } from './pages/genero/listargenero/listargenero.component';
import { CadastrargeneroComponent } from './pages/genero/cadastrargenero/cadastrargenero.component';

@NgModule({
  declarations: [
    AppComponent,
    ListarlivroComponent,
    CadastrarlivroComponent,
    ListargeneroComponent,
    CadastrargeneroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
