<script setup lang="ts">
defineProps<{
  msg: string
}>()
</script>

<template>
  <div class="greetings">
    <h1 class="green">{{ msg }}</h1>
    <button type="button" class="btn btn-primary">Primary</button>
  </div>
</template>
