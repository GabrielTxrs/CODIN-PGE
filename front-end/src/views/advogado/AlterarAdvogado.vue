<template>
    <div>

        <form @submit.prevent="atualizarAdvogado" class="alterar-form">
            <h2>Alterar Advogado de ID: {{ idAdvogado }}</h2>
            <div class="row">
                <div class="col-lg-4 md-4 sm-8">
                    <fieldset>
                        <legend>Dados básicos:</legend>
                        <label for="nomePessoaFisica">Nome Completo*</label>
                        <input type="text" id="nomePessoaFisica" v-model="advogado.nomePessoaFisica" maxlength="100"
                            required />

                        <label for="nomeSocial">Nome Social</label>
                        <input type="text" id="nomeSocial" v-model="advogado.nomeSocial" maxlength="100" />

                        <label for="cpf">CPF*</label>
                        <input type="text" id="cpf" v-model="advogado.cpf" maxlength="11" @input="filterNumeric('cpf')"
                            required />

                        <label for="dataNascimento">Data de Nascimento*</label>
                        <VueDatePicker v-model="advogado.dataNascimento" :enableTimePicker="false"
                            placeholder="dd/mm/yyyy" teleport-center required />
                    </fieldset>
                </div>

                <div class="col-lg-4 md-4 sm-8">
                    <fieldset>
                        <legend>Contato:</legend>
                        <label for="celular">Celular*</label>
                        <input type="text" id="celular" v-model="advogado.celular" maxlength="14"
                            @input="filterNumeric('celular')" required />

                        <label for="telefone">Telefone</label>
                        <input type="text" id="telefone" v-model="advogado.telefone" maxlength="14"
                            @input="filterNumeric('telefone')" />

                        <label for="email">Email*</label>
                        <input type="email" id="email" v-model="advogado.email" maxlength="60" required />
                    </fieldset>
                    <button class="btn btn-primary m-4 p-1" type="submit">Alterar Dados Cadastrais</button>
                </div>
                <div class="col-lg-4 md-4 sm-8">
                    <legend>Profissão:</legend>

                    <label for="oab">Oab*</label>
                    <input type="text" id="oab" v-model="advogado.oab" maxlength="100" required />

                    <label for="oab">Procurador*</label>
                    <div class="radio-group">
                        <div class="form-check">
                            <input class="form-check-input" type="radio" id="procuradorSim" name="isProcurador"
                                v-model="advogado.isProcurador" :value="true">
                            <label class="form-check-label" for="procuradorSim">Sim</label>
                        </div>
                        <div class="form-check">
                            <input class="form-check-input" type="radio" id="procuradorNao" name="isProcurador"
                                v-model="advogado.isProcurador" :value="false">
                            <label class="form-check-label" for="procuradorNao">Não</label>
                        </div>
                    </div>
                </div>

            </div>
        </form>

    </div>
</template>

<script setup>
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css';
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";
import axios from 'axios';

const route = useRoute();
const idAdvogado = route.params.idAdvogado;

let advogado = ref({
    idAdvogado: "",
    oab: "",
    isProcurador: "",
    nomePessoaFisica: "",
    nomeSocial: "",
    cpf: "",
    dataNascimento: "",
    email: "",
    telefone: "",
    celular: ""
});

async function buscarAdvogado(idAdvogado) {
    try {
        let id = '';
        const params = new URLSearchParams();
        if (idAdvogado != undefined && idAdvogado != '') {
            id = idAdvogado;
            params.append('id', id);
        }

        axios.get('https://localhost:7251/get-advogado-filtro', {
            params: params
        }).then((resposta) => {
            console.log(resposta.data);
            advogado.value = resposta.data[0];
        });
    } catch (error) {
        console.error('Erro ao buscar advogados:', error);
    }
}
function atualizarAdvogado() {
    try {
        const Advogado = {
            nomePessoaFisica: advogado.value.nomePessoaFisica,
            oab: advogado.value.oab,
            isProcurador: advogado.value.isProcurador,
            nomeSocial: advogado.value.nomeSocial,
            cpf: advogado.value.cpf,
            celular: advogado.value.celular,
            telefone: advogado.value.telefone,
            email: advogado.value.email,
            dataNascimento: advogado.value.dataNascimento,
        };
        console.log("enviando")
        axios.put(`https://localhost:7251/update-advogado/${advogado.value.idAdvogado}`, Advogado)
            .then(response => {
                console.log('Advogado atualizado com sucesso:', response.data);
            });
    } catch (error) {
        console.error('Erro ao cadastrar advogado:', error);
    }

}

function filterNumeric(field) {
    advogado.value[field] = advogado.value[field].replace(/\D/g, '');
}

onMounted(() => {
    buscarAdvogado(idAdvogado);
});
</script>

<style scoped>
.alterar-form {
    display: flex;
    flex-direction: column;
    gap: 1rem;
    margin: 3rem;
}

.alterar-form label {
    font-weight: bold;
}

.alterar-form input {
    padding: 0.5rem;
    width: 100%;
}

.radio-group {
    align-items: center;
    width: 14%;
}

.form-check {
    margin-right: 0.7rem;
}
</style>