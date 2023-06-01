<template>
  <main>
    <div v-if="isLoading">Loading...</div>
    <div v-else-if="pageResult">
      <ul>
        <li v-for="game in pageResult.items" :key="game.id">
          {{ game.title }}
        </li>
      </ul>
      <base-pagination
        :currentPage="page"
        :totalPages="pageResult.totalPages"
        :hasNext="pageResult.hasNextPage"
        :hasPrevious="pageResult.hasPreviousPage"
        @page-changed="selectPage"
      />
    </div>
  </main>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { gamesService } from '@/services/'
import type { GamesPageResult } from '@/types/gameTypes'
import BasePagination from '@/components/ui/BasePagination.vue'

export default defineComponent({
  components: {
    BasePagination
  },
  data() {
    return {
      pageResult: {} as GamesPageResult,
      page: 1 as number,
      pageSize: 10,
      isLoading: false
    }
  },
  methods: {
    async loadGamesPage(): Promise<void> {
      this.isLoading = true
      const { data, status } = await gamesService.getPage(this.page, this.pageSize)
      this.pageResult = data
      this.isLoading = false
      console.log('response status is: ', status)
    },
    selectPage(page: number) {
      this.page = page
      this.loadGamesPage()
    }
  },
  created() {
    this.loadGamesPage()
  }
})
</script>
