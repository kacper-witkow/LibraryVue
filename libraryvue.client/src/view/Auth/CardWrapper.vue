<template>
  <Card class="m-2 flex w-2/4 flex-col items-center justify-center">
    <CardHeader>
      <CardTitle>{{ title }}</CardTitle>
    </CardHeader>
    <CardContent class="w-2/3">
      <slot></slot>
    </CardContent>
    <CardFooter v-if="!backHrefText">
      <RouterLink :to="backHrefLink">{{ backHrefText }}</RouterLink>
    </CardFooter>
  </Card>
</template>
<script>
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
export default {
  components: {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
    CardHeader,
    CardTitle,
  },
  props: {
    title: String,
    backHrefText: String,
    backHrefLink: String,
  },
};
</script>
