import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Departamento } from '../models/Departamento';
import { DepartamentoService } from './departamento.service';


@Component({
  selector: 'app-departamento',
  templateUrl: './departamento.component.html',
  styleUrls: ['./departamento.component.css']
})


export class DepartamentoComponent implements OnInit {
  public modalRef?: BsModalRef;
  public departamentoForm!: FormGroup;
  public titulo = 'Departamentos';
  public departamentosSelecionado?: Departamento;
  public textSimple!: string;
  public departamentos!: Departamento[];
  public modo = 'post';

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder, 
              private modalService: BsModalService,
              private departamentoService: DepartamentoService) { 
    this.criarForm();
  }


  ngOnInit() {
    this.carregarDepartamentos();
  }

  carregarDepartamentos(){
    this.departamentoService.getAll().subscribe(
      (departamentos: Departamento[]) => {
        this.departamentos = departamentos;
        console.log("carregado");
        
      },
      (erro: any) => {
        console.error(erro);
        
      }
    );
  };

  criarForm(){
    this.departamentoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      
    });
  }
  //refatorar quando tiver tempo
  salvarDepartamento(departamento: Departamento){
    (departamento.id === 0) ? this.modo = 'post' : this.modo = 'put';

    if(this.modo === 'post'){
      this.departamentoService.post(departamento).subscribe(
        () => {
          this.carregarDepartamentos();
          console.log();
          
        },  //caso comece a dar erro na hora de salvar 30 min e 40 
        (erro: any) => {
          console.error(erro);
          
        }
      )
    }else{
      this.departamentoService.put(departamento.id, departamento).subscribe(
        () => {
          this.carregarDepartamentos();
          console.log();
          
        },  //caso comece a dar erro na hora de salvar 30 min e 40 
        (erro: any) => {
          console.error(erro);
          
        }
      )
    }

  }

  departamentoSubmit(){
    this.salvarDepartamento(this.departamentoForm.value);    
  }


  departamentosSelect(departamentos: any ){
    this.departamentosSelecionado = departamentos
    this.departamentoForm.patchValue(departamentos);
  }
  departamentoNovo(){
    this.departamentosSelecionado = new Departamento
    this.departamentoForm.patchValue(this.departamentosSelecionado);
  }
  
  voltar(){
    this.departamentosSelecionado = undefined;
  }
  
  


}
