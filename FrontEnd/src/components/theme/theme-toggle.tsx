import { DesktopIcon, MoonIcon, SunIcon } from '@phosphor-icons/react'
import { Button } from '../ui/button'
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from '../ui/dropdown-menu'
import { useTheme } from './theme-provider'

export function ThemeToggle() {
  const { setTheme } = useTheme()

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="theme" size="icon">
          <SunIcon weight='fill' className="text-c3 h-[1.2rem] w-[1.2rem] rotate-0 scale-100 transition-all dark:-rotate-90 dark:scale-0" />
          <MoonIcon weight="fill" className="text-c3 absolute h-[1.2rem] w-[1.2rem] rotate-90 scale-0 transition-all dark:rotate-0 dark:scale-100" />
          <span className="sr-only">Toggle theme</span>
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end" className='divide-y divide-sidebar-border'>
        <DropdownMenuItem onClick={() => setTheme('light')} className='py-3 cursor-pointer'>
          <SunIcon weight='fill'/>
          Claro
        </DropdownMenuItem>
        <DropdownMenuItem onClick={() => setTheme('dark')} className='py-3 cursor-pointer'>
          <MoonIcon weight='fill'/>
          Escuro
        </DropdownMenuItem>
        <DropdownMenuItem onClick={() => setTheme('system')} className='py-3 cursor-pointer'>
          <DesktopIcon weight='fill'/>
          Sistema
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  )
}
