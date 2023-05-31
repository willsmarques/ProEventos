import { Evento } from "./Evento";

export interface Lote {


   id: number;
   nome: String;
   preco: number;
   dataInicio: Date;
   dataFim: Date;
   quantidade: number;
   eventoId: number;
   evento: Evento;

}
