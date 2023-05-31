import { Palestrante } from './Palestrante';
import { Evento } from "./Evento";

export interface PalestranteEvento {


   palestranteId: number;
   palestrante: Palestrante;
   eventoId: number;
   evento: Evento;

}
