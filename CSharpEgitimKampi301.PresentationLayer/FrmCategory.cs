﻿using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
	public partial class FrmCategory : Form
	{
		private readonly ICategoryService _categoryService;

		public FrmCategory()
		{
			_categoryService = new CategoryManager(new EfCategoryDal());
			InitializeComponent();
		}

		private void btnList_Click(object sender, EventArgs e)
		{
			var categoryValues = _categoryService.TGetAll();
			dataGridView1.DataSource = categoryValues;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Category category = new Category();
			category.CategoryName = txtCategoryName.Text;
			category.CategoryStatus = true;
			_categoryService.TInsert(category);
			MessageBox.Show("Kategori eklendi.");
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtCategoryId.Text);
			var deletedValue = _categoryService.TGetById(id);
			_categoryService.TDelete(deletedValue);
			MessageBox.Show("Kategori silindi.");
		}

		private void btnGetById_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtCategoryId.Text);
			var values = _categoryService.TGetById(id);
			var categoryList = new List<Category> { values };
			dataGridView1.DataSource = categoryList;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtCategoryId.Text);
			var updatedValue = _categoryService.TGetById(id);
			updatedValue.CategoryName = txtCategoryName.Text;
			updatedValue.CategoryStatus = true;
			_categoryService.TUpdate(updatedValue);
		}
	}
}