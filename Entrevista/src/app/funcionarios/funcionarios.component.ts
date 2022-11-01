import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Funcionario } from '../models/Funcionario';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css'],
  
  
})
export class FuncionariosComponent implements OnInit {
  public modalRef?: BsModalRef;
  public funcionarioForm!: FormGroup;
  public titulo = 'Funcionarios';

  public funcionarioSelecionado: Funcionario | undefined;
  
  public textSimple: string | undefined;

  public funcionarios = [
    {id: 1, nome: 'Jonas', foto: 'Moura', RG: 'xx.xxx.xxx-x', deptId: 2},

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
    this.funcionarioForm = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  funcionarioSubmit(){
    console.log(this.funcionarioForm.value);
    
  }

funcionarioSelect(funcionario:any){
  this.funcionarioSelecionado = funcionario;
  this.funcionarioForm.patchValue(funcionario);
}

voltar(){
  this.funcionarioSelecionado = undefined;
}



}
