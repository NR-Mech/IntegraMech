import * as React from "react"
import { Slot } from "@radix-ui/react-slot"
import { cva, type VariantProps } from "class-variance-authority"

import { cn } from "@/lib/utils"

const buttonVariants = cva(
  "inline-flex items-center justify-center gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0",
  {
    variants: {
      variant: {
        primary:
          "bg-p2 rounded-xl font-bold tracking-wider flex items-center justify-center text-primary-foreground hover:opacity-90 outline-none duration-300 transition-all",
        destructive:
          "bg-destructive text-destructive-foreground hover:opacity-90 outline-none duration-300 transition-all",
        outline:
          "border border-input bg-background hover:bg-accent hover:text-accent-foreground outline-none duration-300 transition-all",
        secondary:
          "bg-transparent font-bold border-2 border-p2 text-p2 tracking-wider pointer hover:opacity-90 outline-none duration-300 transition-all",
        link: "text-primary underline-offset-4 hover:underline outline-none duration-300 transition-all",
        theme:
          "bg-background border rounded-xl border-c3 focus-visible:border-c3 text-foreground outline-none duration-300 transition-all hover:opacity-90",
      },
      size: {
        default: "h-10 px-4 py-2",
        sm: "h-8 rounded-md px-3 text-xs",
        lg: "h-12 rounded-md px-8",
        icon: "h-10 w-10",
      },
    },
    defaultVariants: {
      variant: "primary",
      size: "default",
    },
  }
)

export interface ButtonProps
  extends React.ButtonHTMLAttributes<HTMLButtonElement>,
    VariantProps<typeof buttonVariants> {
  asChild?: boolean
}

const Button = React.forwardRef<HTMLButtonElement, ButtonProps>(
  ({ className, variant, size, asChild = false, ...props }, ref) => {
    const Comp = asChild ? Slot : "button"
    return (
      <Comp
        className={cn(buttonVariants({ variant, size, className }))}
        ref={ref}
        {...props}
      />
    )
  }
)
Button.displayName = "Button"

export { Button, buttonVariants }
