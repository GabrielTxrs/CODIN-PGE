<template>
    <div>
        
        <form @submit.prevent="atualizarCliente" class="alterar-form">
            <h2>Alterar Cliente de ID: {{ idCliente }}</h2>
            <div class="row">
                <div class="col-lg-4 md-4 sm-8">
                    <fieldset>
                        <legend>Dados básicos:</legend>
                        <label for="nomePessoaFisica">Nome Completo*</label>
                        <input type="text" id="nomePessoaFisica" v-model="cliente.nomePessoaFisica" maxlength="100" required />

                        <label for="nomeSocial">Nome Social</label>
                        <input type="text" id="nomeSocial" v-model="cliente.nomeSocial" maxlength="100" />

                        <label for="cpf">CPF*</label>
                        <input type="text" id="cpf" v-model="cliente.cpf" maxlength="11" @input="filterNumeric('cpf')" required />

                        <label for="dataNascimento">Data de Nascimento*</label>
                        <VueDatePicker v-model="cliente.dataNascimento" :enableTimePicker="false" placeholder="dd/mm/yyyy"
                            teleport-center required />
                    </fieldset>
                </div>

                <div class="col-lg-4 md-4 sm-8">
                    <fieldset>
                        <legend>Contato:</legend>
                        <label for="celular">Celular*</label>
                        <input type="text" id="celular" v-model="cliente.celular" maxlength="14" @input="filterNumeric('celular')" required />

                        <label for="telefone">Telefone</label>
                        <input type="text" id="telefone" v-model="cliente.telefone" maxlength="14" @input="filterNumeric('telefone')" />

                        <label for="email">Email*</label>
                        <input type="email" id="email" v-model="cliente.email" maxlength="60" required />
                    </fieldset>
                    <button class="btn btn-primary m-4 p-1" type="submit">Atualizar Cliente</button>
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
const idCliente = route.params.idCliente;

let cliente = ref({
    idCliente: "",
    nomePessoaFisica: "",
    nomeSocial: "",
    cpf: "",
    dataNascimento: "",
    email: "",
    telefone: "",
    celular: ""
});

async function buscarCliente(idCliente) {
    try {
        let id = '';
        const params = new URLSearchParams();
        if (idCliente != undefined && idCliente != '') {
            id = idCliente;
            params.append('id', id);
        }

        axios.get('https://localhost:7251/get-cliente-filtro', {
            params: params
        }).then((resposta) => {
            console.log(resposta.data);
            cliente.value = resposta.data[0];
        });
    } catch (error) {
        console.error('Erro ao buscar clientes:', error);
    }
}
function atualizarCliente() {
    try {
        const Cliente = {
            nomePessoaFisica: cliente.value.nomePessoaFisica,
            nomeSocial: cliente.value.nomeSocial,
            cpf: cliente.value.cpf,
            celular: cliente.value.celular,
            telefone: cliente.value.telefone,
            email: cliente.value.email,
            dataNascimento: cliente.value.dataNascimento,
        };
        console.log("enviando")
        axios.put(`https://localhost:7251/update-cliente/${cliente.value.idCliente}`, Cliente)
        .then(response => {
            console.log('Cliente atualizado com sucesso:', response.data);
        });
    } catch (error) {
        console.error('Erro ao cadastrar cliente:', error);
    }

}

function filterNumeric(field) {
    cliente.value[field] = cliente.value[field].replace(/\D/g, '');
}

onMounted(() => {
    buscarCliente(idCliente);
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
    font-size: 1rem;
    width: 100%;
}
</style>