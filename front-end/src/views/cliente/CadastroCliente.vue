<template>
    <form @submit.prevent="handleSubmit" class="cadastro-form">
        <h2>Cadastro de Cliente</h2>
        <div class="row">
            <div class="col-lg-4 md-4 sm-8">
                <fieldset>
                    <legend>Dados básicos:</legend>
                    <label for="nmPessoaFisica">Nome Completo*</label>
                    <input type="text" id="nmPessoaFisica" v-model="form.nomePessoaFisica" maxlength="100" required />

                    <label for="nmSocial">Nome Social</label>
                    <input type="text" id="nmSocial" v-model="form.nomeSocial" maxlength="100" />

                    <label for="nrCpf">CPF*</label>
                    <input type="text" id="nrCpf" v-model="form.cpf" maxlength="11" @input="filterNumeric('cpf')"
                        required />

                    <label>Data de Nascimento*</label>
                    <VueDatePicker v-model="form.dataNascimento" :enableTimePicker="false" placeholder="dd/mm/yyyy"
                        teleport-center required />
                </fieldset>
            </div>

            <div class="col-lg-4 md-4 sm-8">
                <fieldset>
                    <legend>Contato:</legend>
                    <label for="nrCelular">Celular*</label>
                    <input type="text" id="nrCelular" v-model="form.celular" maxlength="14"
                        @input="filterNumeric('celular')" required />

                    <label for="nrTelefone">Telefone</label>
                    <input type="text" id="nrTelefone" v-model="form.telefone" maxlength="14"
                        @input="filterNumeric('telefone')" />

                    <label for="email">Email*</label>
                    <input type="email" id="email" v-model="form.email" maxlength="60" required />

                </fieldset>
                <button class="btn btn-primary mt-4 p-1" type="submit">Cadastrar</button>
            </div>
        </div>
    </form>
</template>

<script setup>
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'
import { ref } from 'vue';
import axios from 'axios';

const form = ref({
    nomePessoaFisica: '',
    nomeSocial: '',
    cpf: '',
    celular: '',
    telefone: '',
    email: '',
    dataNascimento: null,
});

function handleSubmit() {
    console.log('Form submitted:', form.value);
    try {
        const Cliente = {
            nomePessoaFisica: form.value.nomePessoaFisica,
            nomeSocial: form.value.nomeSocial,
            cpf: form.value.cpf,
            celular: form.value.celular,
            telefone: form.value.telefone,
            email: form.value.email,
            dataNascimento: form.value.dataNascimento,
        };

        console.log(Cliente)
        axios.post('https://localhost:7251/add-cliente', Cliente).then(response => {
            console.log('Cliente cadastrado com sucesso:', response.data);
        });

    } catch (error) {
        console.error('Erro ao cadastrar cliente:', error);
    }
}
function filterNumeric(field) {
    form.value[field] = form.value[field].replace(/\D/g, '');
}

</script>

<style scoped>
.cadastro-form {
    display: flex;
    flex-direction: column;
    gap: 1rem;
    margin: 3rem;
}

.cadastro-form label {
    font-weight: bold;
}

.cadastro-form input {
    padding: 0.5rem;
    font-size: 1rem;
    width: 100%;
}

</style>