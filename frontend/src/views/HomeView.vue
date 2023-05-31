<template>
  <main>
    <ul v-if="games">
      <li v-for="game in games" :key="game.id">
        {{ game.title }}
      </li>
    </ul>
  </main>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { gamesService } from '@/services/'
import type { GameItem } from '@/types/gameTypes'

export default defineComponent({
  data() {
    return {
      games: {} as GameItem[],
      page: 1,
      pageSize: 10
    }
  },
  methods: {
    async loadGamesPage(): Promise<void> {
      const { data, status } = await gamesService.getPage(this.page, this.pageSize)
      this.games = data.items
      console.log('response status is: ', status)
    }
  },
  created() {
    this.loadGamesPage()
  }
})
</script>
