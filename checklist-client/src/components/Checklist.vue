<template>
  <div>
    <input type="text" v-model="newItemText" />
    <button @click="onClickSave"> Save </button>
    <ul>
      <li v-for="item in items" :key="item.id">
        {{ item.text }}
        <button @click="onClickDelete(item.id)"> Delete </button>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newItemText: '',
      items: []
    }
  },
  async mounted() {
    await this.loadItems()
  },
  methods: {
    async onClickSave() {
      await fetch('https://localhost:5001/checklist', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ text: this.newItemText })
      })

      this.newItemText = ''
      await this.loadItems()
    },
    async loadItems() {
      const res = await fetch('https://localhost:5001/checklist')
      this.items = await res.json()
    },
    async onClickDelete(id) {
      await fetch(`https://localhost:5001/checklist/${id}`, {
        method: 'DELETE'
      })

      await this.loadItems()
    }
  }
}
</script>