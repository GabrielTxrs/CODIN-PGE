<template>
  <div class="container">
    <RouterLink class="button" to="/cliente">Menu de Cliente</RouterLink>
    <RouterLink class="button" to="/advogado">Menu de Advogado</RouterLink>
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-items: flex-start;
  height: 100vh; 
  padding-top: 2rem;
}

.button {
  display: inline-block;
  margin: 5rem;
  padding: 15px 30px;
  font-size: 18px;
  color: white;
  background-color: #007bff; 
  border-radius: 5px;
}

.button:hover {
  background-color: #0056b3; /* Darker shade for hover effect */
}
</style>