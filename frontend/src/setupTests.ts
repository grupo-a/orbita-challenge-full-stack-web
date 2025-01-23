import { vi } from 'vitest';
import { config } from '@vue/test-utils';
import { createVuetify } from 'vuetify';
import 'vuetify/styles';

const ResizeObserverMock = vi.fn(() => ({
  observe: vi.fn(),
  unobserve: vi.fn(),
  disconnect: vi.fn(),
}));
vi.stubGlobal('ResizeObserver', ResizeObserverMock);

const vuetify = createVuetify();
config.global.plugins = [vuetify];