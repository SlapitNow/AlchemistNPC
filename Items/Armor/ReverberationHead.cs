using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ReverberationHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reverberation Wreath (T-04-53)");
			DisplayName.AddTranslation(GameCulture.Russian, "Венок Реверберации (T-04-53)"); 
			Tooltip.SetDefault("The sleek surface is tough as if it had been cured several times."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases ranged damage by 20%");
			Tooltip.AddTranslation(GameCulture.Russian, "Гладкая поверхность всё так же прочна, как будто не была восстановлена несколько раз.\n[c/FF0000:Э.П.О.С часть брони]\nПовышает урон в дальнем бою на 20%");
		ModTranslation text = mod.CreateTranslation("ReverberationSetBonus");
		text.SetDefault("Forms shield around weilder. Shield reduces all incoming damage by 15%\nSpeeds up all arrows\nImproves Reverberation Crossbow:\nLowers manacost for additional projectiles\nMakes crossbow shot multiple projectiles");
		text.AddTranslation(GameCulture.Russian, "Создаёт щит вокруг владельца. Щит уменьшает весь входящий урон на 15%\nУскоряет все стрелы\nУлучшает арбалет 'Реверберация'\nУменьшает затраты маны на выстрел дополнительными снарядами\nАрбалет будет выстреливать несколько дополнительных снарядов");
		mod.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 9;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage *= 1.2f;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ReverberationBody") && legs.type == mod.ItemType("ReverberationLegs");
		}

		public override void UpdateArmorSet(Player player)
		{
			string ReverberationSetBonus = Language.GetTextValue("Mods.AlchemistNPC.ReverberationSetBonus");
			player.setBonus = ReverberationSetBonus;
			player.magicQuiver = true;
			player.AddBuff(mod.BuffType("ShieldofSpring"), 300);
			AlchemistNPC.RevSet = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemID.DynastyWood, 100);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}