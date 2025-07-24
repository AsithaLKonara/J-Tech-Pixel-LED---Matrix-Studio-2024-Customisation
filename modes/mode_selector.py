def select_mode(mode_name):
    if mode_name == "Buduras Mala":
        return load_buduras_mala_template()
    elif mode_name == "DJ Panel":
        return load_dj_panel_layout()
    # Add other modes
    else:
        return load_normal_programming_mode()

def load_buduras_mala_template():
    # Return a 150x150 grid with predefined layout
    return [[(255, 0, 0) if (x + y) % 2 == 0 else (0, 0, 0) for x in range(150)] for y in range(150)]