import { Component, OnInit } from '@angular/core';
import { EventoService } from '../service/evento.service';
import { Evento } from 'src/models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  //providers: [EventoService]
})
export class EventosComponent implements OnInit {

  public eventosFiltrados: Evento[] = [];
  public eventos : Evento[] = [];
  public larguraImagem: number = 200;
  public mmargemImagem: number = 2;
  public exibirImagem: boolean = true;
  private _filtroLista: string='';

  public get filtroLista():string{
    return this._filtroLista
  }

  public set filtroLista(value:string){

    this._filtroLista = value;

    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[]{

       filtrarPor = filtrarPor.toLocaleUpperCase();
       return this.eventos.filter(
        (evento: {tema: string; local:string}) => (evento.tema.toLocaleUpperCase().indexOf(filtrarPor) !== -1) ||
                                                  (evento.local.toLocaleUpperCase().indexOf(filtrarPor) !== -1)
        )
  }

 public  constructor(private eventoService: EventoService){}

 public  ngOnInit(): void{
     this.getEventos();

  }

  public alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  public  getEventos(): void{
    this.eventoService.getEventos().subscribe(
      (_evento: Evento[] ) => {this.eventos = _evento;
      this.eventosFiltrados = this.eventos
      },
      error => console.log(error) );

  }

}


