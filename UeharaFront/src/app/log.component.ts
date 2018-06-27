import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material';
import {ApiService} from './log.service'
import {LogRespondeModel} from './models/log'
@Component({
  selector: 'app-root',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit {
  displayedColumns = ['logSistemaId',
                      'data', 
                      'origem', 
                      'contexto',
                      'severidade',
                      'mensagem',
                      'arquivoFonte',
                      'metodoFonte',
                      'maquina',
                      'linhaFonte',
                      'propriedades',
                      'excecao',
                      'origemiD',
                      'logContextoiD',
                      'usuarioiD',
                      'nomeUsuario'
                    ];
  dataSource = new MatTableDataSource();
  logs:LogRespondeModel[]
  constructor(private apiService: ApiService) {
  }
  ngOnInit() {
    var result = this.apiService.getAll().then(logs => {
      console.log(logs,"logs")
      this.dataSource.data = logs
      console.log(this.dataSource,"datasource")
    });
    console.log(result, "result")
    // var result = this.apiService.getAll().subscribe(res=>{
      
    //   console.log(JSON.parse(res.toString()),"string")
    //   console.log(res, "res")
    //   console.log(JSON.stringify(res), "json")
    //   // this.logs = res;
    // }
    //);
    // console.log(result,"result")
    // this.apiService.getUsers().subscribe(
    //   data => {
    //     console.log(data,"data")
    //     this.dataSource.data = data;
    //   }
    // );
   
  }
}
