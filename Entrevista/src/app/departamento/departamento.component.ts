import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Departamento } from '../models/Departamento';

@Component({
  selector: 'app-departamento',
  templateUrl: './departamento.component.html',
  styleUrls: ['./departamento.component.css']
})


export class DepartamentoComponent implements OnInit {
  public modalRef?: BsModalRef;
  public titulo = 'Departamentos';
  public departamentoForm!: FormGroup;
  public departamentosSelecionado: Departamento | undefined;

  public textSimple: string | undefined;

  public departamento = [
    {id: 1, nome: 'financas', sigla: 'fnc' },
    {id: 2, nome: 'administracao',sigla: 'adm' },
    {id: 3, nome: 'Suporte tecnico',sigla: 'ti' },
    {id: 4, nome: 'Recursos Humanos',sigla: 'rh' }

  ];

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }



  constructor(private fb: FormBuilder, private modalService: BsModalService) { 
    this.criarForm();
  }


  ngOnInit() {
  }

  criarForm(){
    this.departamentoForm = this.fb.group({
      nome: ['', Validators.required],
      sigla: ['', Validators.required]
    });
  }

  departamentoSubmit(){
    console.log(this.departamentoForm.value);
    
  }

  departamentosSelect(departamentos: Departamento ){
    this.departamentosSelecionado = departamentos
    this.departamentoForm.patchValue(departamentos);
  }
  voltar(){
    this.departamentosSelecionado = undefined;
  }
  
  


}
