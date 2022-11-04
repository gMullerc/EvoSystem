import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Funcionario } from '../models/Funcionario';
import { FuncionarioService } from './funcionario.service';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css'],
  
  
})
export class FuncionariosComponent implements OnInit {
  public modalRef?: BsModalRef;
  public funcionarioForm!: FormGroup;
  public titulo = 'Funcionarios';
  public funcionarioSelecionado?: Funcionario | null;
  public textSimple!: string;
  public funcionarios!: Funcionario[];
  public modo = 'post';

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private funcionarioService: FuncionarioService) { 
    this.criarForm();
  }
  ngOnInit() {
    this.carregarFuncionarios();
  }
  carregarFuncionarios(){
    this.funcionarioService.getAll().subscribe(
      (funcionarios: Funcionario[]) => {
        this.funcionarios = funcionarios;
      },
      (erro: any) => {
        console.error(erro);
        
      }
    );
  };
  criarForm(){
    this.funcionarioForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }
  //refatorar quando tiver tempo
  salvarFuncionario(funcionario: Funcionario){
    (funcionario.id === 0) ? this.modo = 'post' : this.modo = 'put';
    if(this.modo === 'post'){
      this.funcionarioService.post(funcionario).subscribe(
        () => {
          this.carregarFuncionarios();
          console.log();
          
        },  //caso comece a dar erro na hora de salvar 30 min e 40 
        (erro: any) => {
          console.error(erro);
          
        }
      )
    }else{
      this.funcionarioService.put(funcionario.id, funcionario).subscribe(
        () => {
          this.carregarFuncionarios();
          console.log();
          
        },  //caso comece a dar erro na hora de salvar 30 min e 40 
        (erro: any) => {
          console.error(erro);
          
        }
      )
    }

  }
  
  funcionarioSubmit(){
    this.salvarFuncionario(this.funcionarioForm.value);    
  }


funcionarioSelect(funcionario: Funcionario){
  this.funcionarioSelecionado = funcionario;
  this.funcionarioForm.patchValue(funcionario);
}
funcionarioNovo(){
  this.funcionarioSelecionado = new Funcionario();
  this.funcionarioForm.patchValue(this.funcionarioSelecionado);
}

Deletar(id: number){
  this.funcionarioService.delete(id).subscribe(
    (model: any)=> {
      this.carregarFuncionarios();
      console.log(model);
      
    },
    (erro: any)=> {
      console.error(erro);
      
    }

  )
}

voltar(){
  this.funcionarioSelecionado = null;
}



}
