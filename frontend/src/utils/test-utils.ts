import { mount, VueWrapper } from '@vue/test-utils';
import { createVuetify } from 'vuetify';
import 'vuetify/styles';
import { VApp } from 'vuetify/components';
import type { ComponentPublicInstance } from 'vue';

const vuetify = createVuetify();

export function mountWithVuetify(
  component: any,
  options: Record<string, any> = {}
): VueWrapper<ComponentPublicInstance> {
  return mount(component, {
    global: {
      plugins: [vuetify],
      components: { VApp },
    },
    slots: {
      default: '<v-app></v-app>',
    },
    ...options,
  });
}